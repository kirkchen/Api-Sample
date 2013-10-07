#language: zh-TW
功能: 稽核欄位新增或更新時自動寫入紀錄功能
	提供給 DA層
	當資料欄位被標記為需要稽核時，當資料新增至Table或更新時，
	自動寫入稽核紀錄

背景: 
	假設 目前登入的使用者為Kirk
	並且 ShopContext自動寫入稽核紀錄

場景: 當新增資料時，自動寫入一筆稽核紀錄，記錄新增值
	假設 新增分類資料
		| Name   |
		| Fruits |	
	那麼 資料庫中包含資料
		| Name   | IsValid |
		| Fruits | true    |
	並且 稽核紀錄包含資料
		| IdentifyName | OriginValue | NewValue |
		| Category     |             | Fruits   |

場景: 當更新資料時，自動寫入一筆稽核紀錄，記錄舊值與新值
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