#language: zh-TW
@ignore
功能: 儲存資料自動更新系統資訊功能
	提供給 DA層
	當系統進行Insert、Update時，自動更新系統欄位

背景: 
	假設 目前登入的使用者為Kirk
	並且 ShopContext更新時會自動更新系統資訊

場景: 執行新增分類後，分類儲存會自動帶入使用者名稱
	假設 新增分類資料
		| Name   |
		| Fruits |
	當 新增完畢
	那麼 資料庫中包含資料
		| Name   | CreatedBy | UpdatedBy |
		| Fruits | Kirk      | Kirk      |

場景: 執行更新分類後，分類更新資訊會自動帶入使用者名稱
	假設 新增分類資料
		| Name   | 
		| Fruits | 
    假設 更換使用者為David
	當 更新分類名字為Fruit
	那麼 資料庫中包含資料
		| Name  | CreatedBy | UpdatedBy |
		| Fruit | Kirk      | David     |