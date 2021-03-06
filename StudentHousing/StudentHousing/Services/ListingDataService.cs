﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentHousing.Data;
using StudentHousing.Models;

namespace StudentHousing.Services
{
    public class ListingDataService : IDataService
    {
        private ListingDbContext _context;
        public ListingDataService(ListingDbContext Context)
        {
            _context = Context;
        }
        public ListingModel Add(ListingModel newListing)
        {
            foreach(Images myImage in newListing.Images)
            {
                _context.Add(myImage);
            }
            _context.Add(newListing);
            _context.SaveChanges();
            return newListing;
        }

        public ListingModel Get(int id)
        {
            //ListingModel myItem = _context.Items.FirstOrDefault(x => x.Id == id);
            ListingModel myItem = _context.Items.Include(list => list.Images).FirstOrDefault(x => x.Id == id);
            return myItem;
        }
        public ListingModel GetListingOnly(int id)
        {
            ListingModel myItem = _context.Items.FirstOrDefault(x => x.Id == id);
            //ListingModel myItem = _context.Items.Include(list => list.Images).FirstOrDefault(x => x.Id == id);
            return myItem;
        }

        public IEnumerable<ListingModel> GetAll()
        {
            return _context.Items.OrderBy(x => x.Name).Where(x => x.IsActive == true);
        }

        public ListingModel Update(ListingModel listing)
        {
            
            _context.Attach(listing).State = EntityState.Modified;
            _context.SaveChanges();
            return listing;
        }
        public List<Images> GetImagesOnly(int id)
        {
            List<Images> Images = new List<Images>();
            foreach(Images img in _context.Items.Include(list => list.Images).FirstOrDefault(x => x.Id == id).Images)
            {
                Images.Add(img);
            }
            return Images;
        }

        public IEnumerable<ListingModel> AllFromUser(string userId)
        {
            return _context.Items.OrderBy(x => x.Name).Where(x => x.CreatedBy == userId);
        }

        //public void AttachImages()
        //{
        //    this.
        //}



    }
}
