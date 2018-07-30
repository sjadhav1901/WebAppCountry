using Contracts.Enums;
using Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Models
{
    public class Country
    {
        public int  Id { get; set; }
        public Guid AltId { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }
        public string AlphaTwoCode { get; set; }
        public string AlphaThreeCode { get; set; }
        public string Capital { get; set; }
        public string Flags { get; set; }
        public string Area { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public long Population { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string TimeZone { get; set; }
        public bool IsEnabled { get; set; }
    }
}
