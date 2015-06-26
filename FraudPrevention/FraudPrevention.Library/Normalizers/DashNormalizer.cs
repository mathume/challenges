using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudPrevention.Normalizers
{
    public class DashNormalizer: INormalizer
    {
        public string Normalize(string p)
        {
            return p.Replace("-", "");
        }
    }
}
