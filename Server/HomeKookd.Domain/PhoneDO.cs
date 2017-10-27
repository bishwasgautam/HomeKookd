using System;
using System.Linq;

namespace HomeKookd.Domain
{
    public class PhoneDo
    {
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public bool IsActive { get; set; }

        public (string, string, string, string) FormParts(string pNumber)
        {
            if (pNumber.Length >= 10)
            {
                var indexAfterCountryCode = Math.Min(pNumber.Length - 10, 3); //Country code max length is 3

                var formattedWithoutCountryCodeOrExtension = string.Format("{0:###-###-####}",
                    double.Parse(pNumber.Substring(indexAfterCountryCode, 10)));

                var parts = formattedWithoutCountryCodeOrExtension.Split('-').ToArray();

                CountryCode = pNumber.Substring(0, indexAfterCountryCode);
                AreaCode = parts[0] ?? string.Empty;
                PhoneNumber = string.Concat(parts[1]?? string.Empty, parts[2]?? string.Empty);
                Extension = pNumber.Substring(indexAfterCountryCode + 10);
            }

            return (CountryCode, AreaCode, PhoneNumber, Extension);
        }

        public override bool Equals(object obj)
        {
            return obj is PhoneDo pDo && pDo.FormParts(string.Concat(pDo.CountryCode, pDo.AreaCode, pDo.PhoneNumber, pDo.Extension))
                       .Equals(FormParts(string.Concat(CountryCode, AreaCode, PhoneNumber, Extension)));
        }
    }
}
