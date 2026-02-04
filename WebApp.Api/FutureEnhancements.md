1. Admin authorization (custom attributes) for inventory endpoints, etc.
2. Upload excel of products for bulk uploads (admin inventroy endpoint for bul upload option)
3. Price currency change based on geo / region


## Bugs
Then in the code we see Product object being initialized with Category object as a property
When we make call to get all products
Then we do not see the category object in the product we just added from api
We see null as Category in Product but we get Category Id as we passed from From body in product dto

### Issue: Category property is null after adding product
**Steps to reproduce:**
1. Add a product to inventory using the API, providing a valid Category Id in the request body (ProductDto).
2. The Product object is created with the CategoryId set, but the Category navigation property is not set.
3. Call the API to get all products.

**Expected:**
The returned product should have the Category object populated (not null) if the CategoryId is valid.

**Actual:**
The returned product has the correct CategoryId, but the Category property is null.

**Notes:**
- This happens because EF Core does not automatically populate navigation properties after inserting entities unless explicitly loaded (e.g., using .Include() when querying).
- The issue is visible when calling the get all products endpoint after adding a product via the API.