using System;
using AutoMapper;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ApiSample.Models;
using System.Collections.Generic;

namespace ApiSample.BL.Mappings.Test
{
    [Binding]
    public class 字串轉換為Gift功能步驟
    {
        private string giftString = string.Empty;

        private GiftModel gift;

        private IEnumerable<GiftModel> giftList;

        [Given(@"使用GiftModelMappingProfile")]
        public void 假設使用GiftModelMappingProfile()
        {
            Mapper.AddProfile<GiftModelMappingProfile>();
            Mapper.AssertConfigurationIsValid();
        }

        [Given(@"輸入字串為(.*)")]
        public void 假設輸入字串為(string giftString)
        {
            this.giftString = giftString;
        }

        [When(@"執行轉換字串為Gift Model")]
        public void 當執行轉換字串為GiftModel()
        {
            this.gift = Mapper.Map<GiftModel>(this.giftString);
        }

        [Then(@"Gift Model為")]
        public void 那麼GiftModel為(Table table)
        {
            table.CompareToInstance(this.gift);
        }

        [When(@"執行轉換字串為Gift List")]
        public void 當執行轉換字串為GiftList()
        {
            this.giftList = Mapper.Map<IEnumerable<GiftModel>>(this.giftString);
        }

        [Then(@"Gift List為")]
        public void 那麼GiftList為(Table table)
        {
            table.CompareToSet(this.giftList);
        }

    }
}
