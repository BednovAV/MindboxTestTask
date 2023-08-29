SELECT 
	Products.name AS 'Имя продукта',
	Categories.name AS 'Имя категории'
FROM Products 
	LEFT JOIN product_category on Products.id = product_category.product_id
    LEFT JOIN Categories ON Categories.id = product_category.category_id