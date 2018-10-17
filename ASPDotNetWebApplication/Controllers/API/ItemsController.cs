using ASPDotNetWebApplication.Context;
using ASPDotNetWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using ASPDotNetWebApplication.Dtos;

namespace ASPDotNetWebApplication.Controllers.API
{
    public class ItemsController : ApiController
    {
        private AppDbContext _context;
        
        public ItemsController()
        {
            _context = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //GET /api/items
        public IEnumerable<ItemDTO> GetItems()
        {
            return _context.Items.ToList().Select(Mapper.Map<Item,ItemDTO>);
        }

        //GET /api/items/{id}
        public ItemDTO GetItem(int Id)
        {
            var Item = _context.Items.Include(it => it.Features).SingleOrDefault(i => i.Id == Id && i.Status == 1);
            if(Item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Item, ItemDTO>(Item);
        }

        //POST /api/items
        [HttpPost]
        public ItemDTO CreateItem(ItemDTO itemDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Item item = Mapper.Map<ItemDTO, Item>(itemDTO);
            _context.Items.Add(item);
            _context.SaveChanges();
            return itemDTO;
        }

        //PUT /api/items/{id}
        [HttpPut]
        public void UpdateItem(int Id, ItemDTO itemDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var ItemInDb = _context.Items.SingleOrDefault(i => i.Id == Id);
            if(ItemInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Item item = Mapper.Map<ItemDTO, Item>(itemDTO);
            ItemInDb.Name = item.Name;
            ItemInDb.Status = item.Status;

            _context.SaveChanges();
        }

        //DELETE api/items/{id}
        [HttpDelete]
        public void RemoveItem(int Id)
        {
            var ItemInDb = _context.Items.SingleOrDefault(i => i.Id == Id);
            if(ItemInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Items.Remove(ItemInDb);
            _context.SaveChanges();
        }
    }
}
