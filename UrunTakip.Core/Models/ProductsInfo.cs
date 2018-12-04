﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunTakip.Core.Models
{
    public class ProductsInfo
    {
        public int Id { get; set; }
        public string QName { get; set; }
        public string Date { get; set; }
        public string CustomerName { get; set; }
        public string Amount { get; set; }
        public string Color { get; set; }
        public string Chemical { get; set; }
        public string ChemicalProduct { get; set; }
        public string Txt1 { get; set; }
        public string Processing { get; set; }
        public string DateOfProcessing { get; set; }
        public string EndProcessingDate { get; set; }
        public string Date2 { get; set; }
        public string Manager { get; set; }
        public bool IsActive { get; set; }
    }
}
