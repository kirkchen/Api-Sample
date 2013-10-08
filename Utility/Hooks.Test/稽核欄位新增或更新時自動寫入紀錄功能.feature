#language: zh-TW
功能: 稽核欄位新增或更新時自動寫入紀錄功能
	提供給 DA層
	當資料欄位被標記為需要稽核時，當資料新增至Table或更新時，
	自動寫入稽核紀錄

背景: 
	假設 目前登入的使用者為Kirk
	並且 ShopContext自動寫入稽核紀錄

場景: 當新增分類資料時，自動寫入一筆稽核紀錄，記錄新增值
	假設 新增分類資料
		| Name   |
		| Fruits |	
	那麼 資料庫中包含資料
		| Name   | IsValid |
		| Fruits | true    |
	並且 稽核紀錄包含資料
		| IdentifyName | OriginValue | NewValue |
		| Category     |             | Fruits   |

場景: 當更新分類資料時，自動寫入一筆稽核紀錄，記錄舊值與新值
	假設 新增分類資料
		| Name   |
		| Fruits |	
	當 更新分類名字為Fruit
	那麼 資料庫中包含資料
		| Name  | IsValid |
		| Fruit | true    |
	並且 稽核紀錄包含資料
		| IdentifyName | OriginValue | NewValue |
		| Category     |             | Fruits   |
		| Category     | Fruits      | Fruit    |

場景: 當新增商品資料時，自動寫入稽核紀錄，記錄新增值
	假設 新增分類資料
		| Id | Name   |
		| 1  | Fruits |
	並且 新增商品資料
		| CategoryId | Name         | Price | Cost | ListingStartTime | ListingEndTime | SellingStartTime | SellingEndTime | IsValid |
		| 1          | Hamburger    | 99    | 50   | 2013-10-01       | 2014-10-01     | 2013-10-01       | 2014-10-01     | true    |
		| 1          | Sandwitch    | 89    | 40   | 2013-10-01       | 2014-10-01     | 2013-10-01       | 2014-10-01     | true    |
	那麼 資料庫中包含資料
		| Name   | IsValid |
		| Fruits | true    |
	並且 資料庫中包含商品資料
		| Name      | Price | Cost | ListingStartTime | ListingEndTime | SellingStartTime | SellingEndTime | IsValid |
		| Hamburger | 99    | 50   | 2013-10-01       | 2014-10-01     | 2013-10-01       | 2014-10-01     | true    |
		| Sandwitch | 89    | 40   | 2013-10-01       | 2014-10-01     | 2013-10-01       | 2014-10-01     | true    |
	並且 稽核紀錄包含資料
		| IdentifyName | OriginValue | NewValue |
		| Category     |             | Fruits   |
		| Product      |             | 99       |
		| Product      |             | 50       |
		| Product      |             | 89       |
		| Product      |             | 40       |