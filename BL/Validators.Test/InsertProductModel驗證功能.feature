#language: zh-TW
功能: InsertProductModel驗證功能
	提供給 BL層
	使用者輸入InsertProductModel資料，驗證資料是否正確

場景: 輸入資料正確，驗證成功
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 200   | 100  |              | 2013-10-01     | 2014-10-01      | 2013-10-01  | 2014-10-01   | 1          |
	假設 資料庫存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證成功

場景: 輸入姓名為空，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		|      | 200   | 100  |              | 2013-10-01     | 2014-10-01      | 2013-10-01  | 2014-10-01   | 1          |
	假設 資料庫存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入姓名長度超過100，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		|      | 200   | 100  |              | 2013-10-01     | 2014-10-01      | 2013-10-01  | 2014-10-01   | 1          |
	假設 資料庫存在分類序號1
	並且 姓名長度超過100
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入價格為0，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 0   | 100  |              | 2013-10-01     | 2014-10-01      | 2013-10-01  | 2014-10-01   | 1          |
	假設 資料庫存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入價格小於成本，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 99    | 100  |              | 2013-10-01     | 2014-10-01      | 2013-10-01  | 2014-10-01   | 1          |
	假設 資料庫存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入成本為0，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 200   | 0    |              | 2013-10-01     | 2014-10-01      | 2013-10-01  | 2014-10-01   | 1          |
	假設 資料庫存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入成本大於售價，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 200   | 300  |              | 2013-10-01     | 2014-10-01      | 2013-10-01  | 2014-10-01   | 1          |
	假設 資料庫存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入介紹超過1000，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 200   | 100  |              | 2013-10-01     | 2014-10-01      | 2013-10-01  | 2014-10-01   | 1          |
	假設 資料庫存在分類序號1
	並且 介紹長度超過1000
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入開賣時間為空，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 200   | 100  |              | 2013-10-01     | 2014-10-01      |             | 2014-10-01   | 1          |
	假設 資料庫存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入開賣時間晚於開賣結束時間，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 200   | 100  |              | 2013-10-01     | 2014-10-01      | 2015-10-01  | 2014-10-01   | 1          |
	假設 資料庫存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入開賣結束時間為空，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 200   | 100  |              | 2013-10-01     | 2014-10-01      | 2013-10-01  |              | 1          |
	假設 資料庫存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入開賣結束時間早於開賣時間，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 200   | 100  |              | 2013-10-01     | 2014-10-01      | 2013-10-01  | 2012-10-01   | 1          |
	假設 資料庫存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入上架時間為空，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 200   | 100  |              |                | 2014-10-01      | 2013-10-01  | 2014-10-01   | 1          |
	假設 資料庫存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入上架時間晚於開賣時間，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 200   | 100  |              | 2015-10-01     | 2014-10-01      | 2013-10-01  | 2014-10-01   | 1          |
	假設 資料庫存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入下架時間為空，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 200   | 100  |              | 2013-10-01     |                 | 2013-10-01  | 2014-10-01   | 1          |
	假設 資料庫存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入下架時間早於開賣結束時間，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 200   | 100  |              | 2013-10-01     | 2012-10-01      | 2013-10-01  | 2014-10-01   | 1          |
	假設 資料庫存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入分類資料為空，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 200   | 100  |              | 2013-10-01     | 2014-10-01      | 2013-10-01  | 2014-10-01   | 0          |
	假設 資料庫存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證失敗

場景: 輸入分類不存在資料庫中，驗證失敗
	假設 使用者輸入InsertProductModel資料
		| Name | Price | Cost | Introduction | StartListingAt | FinishListingAt | StartSellAt | FinishSellAt | CategoryId |
		| Test | 200   | 100  |              | 2013-10-01     | 2014-10-01      | 2013-10-01  | 2014-10-01   | 1          |
	假設 資料庫不存在分類序號1
	當 執行InsertProductModel驗證
	那麼 驗證失敗