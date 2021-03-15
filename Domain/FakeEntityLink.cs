using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class FakeEntityLink
    {
        public FakeEntity FakeEntity { get; set; }
        public int FakeEntityId { get; set; }
        //public int BillParamTypeEnumId { get; set; }

        public BillParamTypeEnum2 BillParamTypeEnum2 { get; private set; } = BillParamTypeEnum2.PriceCategory;

        private FakeEntityLink() { }
        public FakeEntityLink(FakeEntity fakeEntity, BillParamTypeEnum2 billParamTypeEnum)
        {
            FakeEntity = fakeEntity;
            BillParamTypeEnum2 = billParamTypeEnum;
        }
    }
}
