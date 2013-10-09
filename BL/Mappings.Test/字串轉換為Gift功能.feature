#language: zh-TW
功能: 字串轉換為Gift功能
	提供給 BL層
	使用者輸入Gift格式為字串，將字串轉換為GiftModel

背景: 
	假設 使用GiftModelMappingProfile

場景: 字串轉換為Gift Model
	假設 輸入字串為Gift1:AAA
	當 執行轉換字串為Gift Model
	那麼 Gift Model為
		| Name  | Description |
		| Gift1 | AAA         |

場景: 字串轉換為Gift List
	假設 輸入字串為Gift1:AAA;Gift2:BBB;Gift3:CCC
	當 執行轉換字串為Gift List
	那麼 Gift List為
		| Name  | Description |
		| Gift1 | AAA         |
		| Gift2 | BBB         |
		| Gift3 | CCC         |

