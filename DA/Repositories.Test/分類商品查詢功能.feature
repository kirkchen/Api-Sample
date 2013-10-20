#language: zh-TW
@ignore
功能: 分類商品查詢功能
	提供給 BL層
	查詢分類下的商品有哪些，並自動判斷商品是否在上架時間之內

背景:
	假設 資料庫中有分類資料
		| Id | Name   |
		| 1  | Foods  |
		| 2  | Drinks |
		| 3  | Fruits |
	並且 資料庫中有產品資料
		| CategoryId | Name         | Price | Cost | ListingStartTime | ListingEndTime | SellingStartTime | SellingEndTime | IsValid |
		| 1          | Hamburger    | 99    | 50   | 2013-10-01       | 2014-10-01     | 2013-10-01       | 2014-10-01     | true    |
		| 1          | Sandwitch    | 89    | 40   | 2013-10-01       | 2014-10-01     | 2013-10-01       | 2014-10-01     | true    |
		| 2          | Orange Juice | 40    | 20   | 2013-10-01       | 2014-11-01     | 2013-10-01       | 2014-10-01     | true    |
		| 2          | Milk         | 35    | 20   | 2013-11-01       | 2014-11-01     | 2013-11-01       | 2014-10-01     | true    |
		| 3          | Watermelon   | 50    | 25   | 2013-10-01       | 2014-11-01     | 2013-11-01       | 2014-10-01     | true    |
		| 3          | Banana       | 50    | 25   | 2013-10-01       | 2014-11-01     | 2013-11-01       | 2014-10-01     | false   |

場景: 根據分類序號查詢商品，假設分類下所有商品上架時間都符合，查詢得到所有商品
	假設 當查詢分類1的商品時
	當 執行分類商品查詢
	那麼 得到商品
		| Name         | Price |
		| Hamburger    | 99    |
		| Sandwitch    | 89    |

場景: 根據分類序號查詢商品，假設分類下有商品上架時間還沒到，查詢得到符合的商品
	假設 當查詢分類2的商品時
	當 執行分類商品查詢
	那麼 得到商品
		| Name         | Price |
		| Orange Juice | 40    |	
		
場景: 根據分類序號查詢商品，過濾IsValid為false(代表刪除)的商品，只查詢服和的商品
	假設 當查詢分類3的商品時
	當 執行分類商品查詢
	那麼 得到商品
		| Name         | Price |
		| Watermelon   | 50    |				

