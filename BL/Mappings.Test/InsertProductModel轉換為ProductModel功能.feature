#language: zh-TW
功能: InsertProductModel轉換為ProductModel功能
	提供給 BL層
	使用者輸入InsertProductModel資料，將資料轉換為ProductModel

背景: 
	假設 使用GiftModelMappingProfile
	假設 使用ProductModelMappingProfile	

場景: 輸入InsertProductModel資料， 轉換為Product Model
	假設 輸入資料為
		| Name    | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId | Gifts     |
		| Product | 200   | 100  | Description  | 2013-10-01     | 2014-10-01      | 2013-10-02  | 2014-09-30   | 1          | Gift1:AAA |
	當 執行轉換為Product Model
	那麼 Product Model為
		| Name    | Price | Cost | Description | ListingStartTime | ListingEndTime | SellingStartTime | SellingEndTime | CategoryId |
		| Product | 200   | 100  | Description | 2013-10-01       | 2014-10-01     | 2013-10-02       | 2014-09-30     | 1          |
	並且 包含Gift List
		| Name  | Description |
		| Gift1 | AAA         |