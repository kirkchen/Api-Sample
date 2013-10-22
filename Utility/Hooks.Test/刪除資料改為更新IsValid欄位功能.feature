#language: zh-TW
@ignore
功能: 刪除資料改為更新IsValid欄位功能
	提供給 DA層
	當系統進行Delete時，並不會真的刪除資料，而是以更新IsValid欄位為False取代
	這樣日後想回復資料時，可以方便取回

背景:
	假設 ShopContext刪除時會以更新IsValid為false取代

場景: 當執行刪除資料時，以更新IsValid欄位為False取代
	假設 新增分類資料
		| Name   |
		| Fruits |
	當 執行刪除分類Fruits
	那麼 資料庫中包含資料
		| Name   | IsValid |
		| Fruits | false   |
	