const request = require('supertest');
const app = require('./index');

describe('Test API', () => {
  it('Get list of goods', async () => {
    const res = await request(app).get('/goods');
    expect(res.statusCode).toEqual(200);
    expect(res.body).toHaveLength(1000);
  });

  it('Add to my bag', async () => {
    const newItem = {
      product_name: 'name',
      product_description: 'desc',
      product_price: 100,
      store_name: 'store',
      store_address: 'address'
    };
    const res = await request(app)
      .post('/add-mybag')
      .send(newItem);
    expect(res.statusCode).toEqual(200);
    expect(res.text).toContain('Element was added to bag');
  });
});
