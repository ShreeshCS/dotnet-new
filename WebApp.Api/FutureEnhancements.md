1. Admin authorization (custom attributes) for inventory endpoints, etc.
2. Upload excel of products for bulk uploads (admin inventroy endpoint for bul upload option)
3. Price currency change based on geo / region


## Bugs
> When we add a product in inventory with a category Id
Then in the code we see Product object being initialized with Category object as a property
When we make call to get all products
Then we do not see the category object in the product we just added from api
We see null as Category in Product but we get Category Id as we passed from From body in product dto