function createItems(items)
{
    var context = getContext();
    var response = context.getResponse();
    
    if(!items)
    {
        response.setBody("Error: Items are undefined");
        return;
    }
    
    var numOfItems = items.length;
    
    checklength(numOfItems);
    
    for(let i = 0; i < numOfItems; i++)
    {
        createItem(items[i]);
    }
    
    response.setBody("Items created: " + numOfItems);
    
    function checklength(itemlength)
    {
        if(itemlength == 0)
        {
            response.setBody("Error: There are no items");
            return;
        }
    }
    
    function createItem(item)
    {
        var collection = getContext().getCollection();
        var collectionLink = collection.getSelfLink();
        collection.createDocument(collectionLink,item); 
    }
}