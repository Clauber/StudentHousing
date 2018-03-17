﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.Models
{
    public class ListingModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public byte[] Image { get; set; }


        //public decimal Rent { get; set; }
        //public decimal DownPayment { get; set; }
        //public string Utilities { get; set; }
        //public string Amendities { get; set; }
        //public string Address1 { get; set; }
        //public string Address2 { get; set; }
        //public string Address3 { get; set; }
        //public string State { get; set; }
        //public string City { get; set; }
        //public int Zip { get; set; }






        //public int PeopleSignedUp { get; set; }
        //public int RoomAvailable { get; set; }
        //public string MyProperty { get; set; }


    }

    //public partial class Images
    //{
    //    public Images()
    //    {
    //        this.ListingModel = new HashSet<ListingModel>();
    //    }
    //}
}