namespace FinalProject0
{
    public class Cart
    {
        //method to add item to cart
        //Think. What do we need in each order: quantity, productId, CustomerId, timestamp, and StoreId
        // class var 
        // public List<Product> products;
        
        // instance var 
        //A list of datatype "Product" because the cart holds all the product.
        public List<Product> cart;
        // constructor
        public Cart(){
            this.cart = new List<Product>();
        }

        // instance methods 

        //we want a method that verifies for 
        public void AddProduct(Product p){
            if (cart.Count > 5){
                Console.WriteLine("cart is full, Oreder may be rejected");
            }
            cart.Add(p);
        }
        // check cart contents
        public int GetCartSize(){
            int cartCOntent = cart.Count;
            return cartCOntent;
        }
    }
}