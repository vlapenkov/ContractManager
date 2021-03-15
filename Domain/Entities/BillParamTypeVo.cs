using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class BillParamTypeVo : ValueObject
    {
        static BillParamTypeVo()
        {
        }

        private BillParamTypeVo()
        {
        }

        private BillParamTypeVo(string code)
        {
            Name = code;
        }

        public static BillParamTypeVo From(string code)
        {
            var colour = new BillParamTypeVo { Name = code };

            if (!SupportedParameters.Contains(colour))
            {
                throw new Exception(code);
            }

            return colour;
        }

        public static BillParamTypeVo PriceCategory => new BillParamTypeVo("Ценовая категория");

        public static BillParamTypeVo VoltageTarifLevel => new BillParamTypeVo("Тарифный уровень напряжения");

        public static BillParamTypeVo Sign => new BillParamTypeVo("Знак вхождения");

        public static BillParamTypeVo VolumeCategory => new BillParamTypeVo("Категория мощности");

       

        public string Name { get; private set; }

        public static implicit operator string(BillParamTypeVo colour)
        {
            return colour.ToString();
        }

        public static explicit operator BillParamTypeVo(string code)
        {
            return From(code);
        }

        public override string ToString()
        {
            return Name;
        }

        protected static IEnumerable<BillParamTypeVo> SupportedParameters
        {
            get
            {
                yield return PriceCategory;
                yield return VoltageTarifLevel;
                yield return Sign;
                yield return VolumeCategory;
             
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
