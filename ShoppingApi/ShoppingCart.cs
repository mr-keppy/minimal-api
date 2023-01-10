namespace ShoppingApi;

public class ShoppingCart
{

        public int ID { get; set; }
        public List<ShoppingItem> List{get;set;}
}
public class ShoppingItem{
        public int ID {get;set;}
        public string Name {get;set;}
}
public class ShoppingList
{       
         public int ID { get; set; }
          public string ItemName { get; set; }
           public int Qty { get; set; }
            public float TotalPrice { get; set; }
}
