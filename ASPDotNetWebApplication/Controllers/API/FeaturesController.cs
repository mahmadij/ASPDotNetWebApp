using ASPDotNetWebApplication.Context;
using ASPDotNetWebApplication.Dtos;
using ASPDotNetWebApplication.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPDotNetWebApplication.Controllers.API
{
    public class FeaturesController : ApiController
    {
        private AppDbContext _context;

        public FeaturesController()
        {
            _context = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET /api/features
        public IEnumerable<FeatureDTO> GetFeatures()
        {
            return _context.Features.ToList().Select(Mapper.Map<Feature, FeatureDTO>);
        }

        //GET /api/features/{id}
        public IHttpActionResult GetFeature(int id)
        {
            var feature = _context.Features.SingleOrDefault(f => f.Id == id);
            if(feature == null)
            {
                NotFound();
            }
            return Ok(Mapper.Map<Feature, FeatureDTO>(feature));
        }

        //POST /api/items
        public IHttpActionResult CreateFeature(FeatureDTO featureDTO)
        {
            var feature = Mapper.Map<FeatureDTO, Feature>(featureDTO);
            _context.Features.Add(feature);
            _context.SaveChanges();
            featureDTO.Id = feature.Id;
            return Created( new Uri(Request.RequestUri+"/"+feature.Id) ,featureDTO);
        }

        //PUT /api/items/{id}
        public IHttpActionResult UpdateFeature(int id, FeatureDTO featureDTO)
        {
            var featureFromDB = _context.Features.SingleOrDefault(f => f.Id == id);
            if(featureFromDB == null)
            {
                NotFound();
            }
            Mapper.Map(featureDTO, featureFromDB);
            return Ok(featureDTO);
        }

        //DELETE /api/items/{id}
        public void DeleteFeature(int id)
        {
            var feature = _context.Features.SingleOrDefault(f => f.Id == id);
            if (feature == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Features.Remove(feature);
            _context.SaveChanges();
        }
    }
}
