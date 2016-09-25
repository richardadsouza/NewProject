using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for DBQuery
/// </summary>
public class DBQuery
{
    public DBQuery()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /********* Admin Side ********/

    public const string checkListProductAlreadyExist = "select * from listlink where list_id=@listid and product_id=@prodid";
    //Retrive shopping constant 
    public const string selectConstantVaraibleInfo = "Select * from shopingConstant";

    public const string selectUsers = "select users_id,(users_lname+' '+ users_fname) as userName,users_lname  from users WHERE location_id =1  ORDER BY users_lname";


    //Sales Dropdown

    public const string selectSales = "SELECT a.product_id, a.product_title, b.productlink_price, b.productlink_id, a.product_size, b.productlink_presale, a.product_image, b.location_id,b.shelf_id,b.aisle_id from product a INNER JOIN productlink b ON b.product_id = a.product_id WHERE productlink_presale IS NOT NULL AND b.location_id =1";


    //Retrive Locations
    public const string selectLocation = "select * from location";
    //Retrive shelf 
    public const string selectShelvesDetailsInfo = "select shelf_id,shelf_name from  shelf order by shelf_name asc";


    //DELIVERY DATE
   // public const string selectDeliveryDate = "select DISTINCT deliverydate_id,Convert(VarChar,deliverydate_date,101) as deliverydate_date  from deliverydate ORDER BY deliverydate_date DESC";

    public const string selectDeliveryDate = "select DISTINCT deliverydate_id,Convert(VarChar,deliverydate_date,101) as deliverydate_date ,Convert(VarChar,deliverydate_date,102) as deliverydate_date1   from deliverydate ORDER BY deliverydate_date1 DESC";


    //State
    public const string selectStateDetailsInfo = "select * from State";

    public const string selectStateDetailsInfoNew = "select * from State where state_short_name=@shortNm";
    //retrive product

    public const string selectProduct = "select p.product_id,p.product_title from product p,productlink pl where p.product_id=pl.product_id and pl.productlink_hide='0' order by p.product_title asc";

    //Login page
    public const string selectLoginInfo = "Select * from admin WHERE admin_email =@username and admin_password=@password";

    //forgot password page
    public const string selectLoginEmailInfo = "Select * from admin WHERE admin_email=@username";

    public const string updateAdminPasswordInfo = "update admin set admin_password=@password  WHERE admin_email=@username";

    public const string selectSideLinkInfo = "SELECT permissions.permissions_permission as id,permissions.permissions_permission as name,permissions.permissions_url as link FROM adminpermissions INNER JOIN permissions ON permissions.permissions_id = adminpermissions.permissions_id WHERE admin_id = @adminId AND permissions_type = @intType ORDER BY permissions_type, permissions_permission";

    //Coupons Code
    public const string selectcouponsCodeAlreadyExist = "select* from coupon where coupon_code=@couponsCode";

    public const string selectcouponsCodeAlreadyUpdateExist = "select* from coupon where coupon_code=@couponsCode and coupon_id!=@CouponId";

    public const string selectUserCouponInfo1 = "SELECT a.users_id, a.coupon_id, b.coupon_code, b.coupon_amount, b.coupon_hide, b.coupon_type FROM couponlink a INNER JOIN coupon b ON b.coupon_id = a.coupon_id WHERE (b.coupon_code = @strCoupon) AND (b.coupon_type = 1)";

    public const string insertCouponsInfo = "insert into coupon(coupon_code,coupon_amount,location_id,coupon_hide,coupon_type)values(@CouponsCode,@amount,@locationId,@status,@CouponType)";

    public const string selectCouponsDetails = "select c.coupon_id,c.coupon_code,c.coupon_amount,c.coupon_hide,loc.location_name from coupon c,location loc where c.location_id=loc.location_id ";

    public const string updateCouponStatus = "update coupon set coupon_hide=@status where coupon_id=@CouponId";

    public const string selectCouponsDetailsInfo = "select * from coupon where coupon_id=@CouponId";

    public const string updateCouponsInfo = "update coupon set coupon_code=@CouponsCode,coupon_amount=@amount,location_id=@locationId where coupon_id=@CouponId";


    //Employee

    public const string selectEmployeePermission = "Select * from permissions ";

    public const string insertEmployeeDetailInfo = "insert into admin(admin_fname,admin_lname,admin_email,admin_password)values(@firstNm,@lastNm,@email,@password); select @@identity";

    public const string insertEmployeePermissionInfo = "insert into adminpermissions(admin_id,permissions_id)values(@adminId,@permissionId)";

    public const string SelectEmployeeDetails = "Select admin_id,admin_fname,admin_lname,admin_email from admin ";//order by admin_lname desc

    public const string deleteEmployee = "delete from admin where admin_id=@adminId";

    public const string deleteEmployeePermission = "delete from adminpermissions where admin_id=@adminId";

    public const string deletelistproductadmin = "delete from listlink where list_id=@list and product_id=@productId";

    public const string SelectEmployeeDetailsInfo = "select * from admin where admin_id=@employeeId";

    public const string selectEmployeePermissionDetails = "select * from adminpermissions where admin_id=@employeeId";

    public const string selectEmployeeEmailInfo = "Select * from admin WHERE admin_email=@email and admin_id!=@adminId";

    public const string updateEmployeeDetailInfo = "update admin set admin_fname=@firstNm,admin_lname=@lastNm,admin_email=@email,admin_password=@password where admin_id=@employeeId";



    //Aisles
    public const string newselectAislelink = "select * from  aislelink where aisle_id=@aisleId";
    public const string selectAislesDetails = "select aisle_id,aisle_name,(case when aisle_show='1'then 'Yes' else 'No' end)as status,imageName from aisle order by aisle_name asc";

    public const string deleteAisle = "delete from  aisle where aisle_id=@aisleId";

    public const string deleteAisleMapping = "delete from  aislelink where aisle_id=@aisleId";

    public const string selectAisleNameAlreadyExist = "select * from aisle where aisle_name=@aisleName";

    public const string insertAisleInfo = "insert into aisle(aisle_name,location_id,aisle_show)values(@aisleName,@locationId,@status); select @@identity";

    public const string selectAislesDetailsInfo = "select * from aisle where aisle_id=@aisleId";

    public const string selectAisleNameUpdateAlreadyExist = "select * from aisle where aisle_name=@aisleName and aisle_id!=@aisleId";

    public const string updateAisleInfo = "update aisle set aisle_name=@aisleName,location_id=@locationId,aisle_show=@status where aisle_id=@aisleId";


    //Aisles Top Aisles

    public const string selectAislesTopAisleDetails = "select aisletop_id,aisletop_name,(case when aisletop_show='1'then 'Yes' else 'No' end)as status,aisletop_image from aisletop order by aisletop_id desc";

    public const string insertAisleTopAisleInfo = "insert into aisletop(aisletop_name,location_id,aisletop_show,aisletop_image)values(@aisletop_name,@locationId,@status,@aisletop_image)";

    public const string selectTopAislesDetailsInfo = "select * from aisletop where aisletop_id=@aisletop_id";

    public const string selectTopAisleNameAlreadyExist = "select * from aisletop where aisletop_name=@aisletop_name";

    public const string updateTopAisleInfo = "update aisletop set aisletop_name=@aisletop_name,location_id=@locationId,aisletop_show=@status,aisletop_image=@aisletop_image where aisletop_id=@aisletop_id";

    public const string selectTopAisleNameUpdateAlreadyExist = "select * from aisletop where aisletop_name=@aisletop_name and aisletop_id!=@aisletop_id";

    public const string deleteTopAisle = "delete from  aisletop where aisletop_id=@aisletop_id";

    public const string deleteTopAisleMapping = "delete from  aisletopaisle where aisletop_id=@aisletop_id";

    public const string insertTopAisleMappingInfo = "insert into aisletopaisle(aisletop_id,aisle_id)values(@aisletop_id,@aisle_id)";

    public const string selectTopAisle = "select aisletop_id,aisletop_name from aisletop where aisletop_show='1' order by aisletop_name asc";

    public const string selectTopAisleMappingDetails = "select  * from  aisletopaisle where aisle_id=@aisle_id";

    public const string selectpremadelistDetails = "select  * from  list where list_type=@type";

    public const string deleteTopAisleMappingInfo = "delete from aisletopaisle where aisle_id=@aisle_id";


    //Shelves

    public const string selectShelvesDetails = "select  * from  shelf order by shelf_name asc";

    public const string deleteShelves = "delete from shelf where shelf_id=@shelvesId";

    public const string deleteShelvesMapping = "delete from aislelink where shelf_id=@shelvesId";

    public const string selectAsile = "select aisle_id,aisle_name from aisle where aisle_show='1' order by aisle_name asc";

    public const string selectShelfNameInfo = "select  * from  shelf where shelf_name=@shelfName";

   // public const string insertShelfDetailInfo = "insert into shelf(shelf_name,shelf_position,shelf_popular,location_id)values(@ShelfName,@Mapping,@popular,@locationId); select @@identity";
    public const string insertShelfDetailInfo = "insert into shelf(shelf_name,shelf_position,shelf_popular,location_id,shelf_show)values(@ShelfName,@Mapping,@popular,@locationId,@Shelfshow); select @@identity";
    public const string insertShelfMappingInfo = "insert into aislelink(aisle_id,shelf_id)values(@aisleId,@shelfId)";

    public const string selectShelfDetailsInfo = "select  * from  shelf where shelf_id=@shelfId";

    public const string selectShelfMappingDetails = "select  * from  aislelink where shelf_id=@shelfId";

    public const string shelfNameUpdateAlreadyExist = "select  * from  shelf where shelf_name=@shelfName and shelf_id!=@shelfId";

    public const string updateShelfDetailInfo = "update shelf set shelf_name=@ShelfName,shelf_show=@shelf_show,shelf_position=@Mapping,shelf_popular=@popular where shelf_id=@shelfId";

    public const string newselectshelfDatainfo="select distinct shelf.shelf_id,aislelink.shelf_id,productlink.shelf_id from shelf,aislelink,productlink  where shelf.shelf_id=aislelink.shelf_id and  shelf.shelf_id=productlink.shelf_id and shelf.shelf_id=@shelvesId";

    //Non-Delivery Zones Reports

    public const string selectdsNonDeliveryZonesDetails = "select future_id,future_email,future_zip,future_name,convert(varchar,future_date,101) as futureDate from future order by  future_date desc";

    public const string deleteNonDeliveryZip = "delete from future where future_id=@intZipID";




    //Product 


    public const string productListDetails = "SELECT a.product_id, a.product_title, a.product_size, a.product_image,a.product_image2,a.product_description, b.productlink_id, b.productlink_hide, b.productlink_buyprice, b.productlink_presale, b.productlink_buyprice, b.productlink_price, b.location_id, d.shelf_name, d.shelf_id, e.location_name,f.aisle_id,f.aisle_name FROM product a INNER JOIN productlink b ON b.product_id = a.product_id INNER JOIN aisle f ON f.aisle_id = b.aisle_id INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId ORDER BY a.product_title";

    public const string productListDetails1 = "SELECT a.product_id, a.product_title, a.product_size, a.product_image,a.product_image2,a.product_description, b.productlink_id, b.productlink_hide, b.productlink_buyprice, b.productlink_presale, b.productlink_buyprice, b.productlink_price, b.location_id, d.shelf_name, d.shelf_id, e.location_name,f.aisle_id,f.aisle_name FROM product a INNER JOIN productlink b ON b.product_id = a.product_id INNER JOIN aisle f ON f.aisle_id = b.aisle_id INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND d.shelf_id =@shefId ORDER BY a.product_title";

    public const string productListDetails2 = "SELECT a.product_id, a.product_title, a.product_size, a.product_image,a.product_image2,a.product_description, b.productlink_id, b.productlink_hide, b.productlink_buyprice, b.productlink_presale, b.productlink_buyprice, b.productlink_price, b.location_id, d.shelf_name, d.shelf_id, e.location_name,f.aisle_id,f.aisle_name FROM product a INNER JOIN productlink b ON b.product_id = a.product_id INNER JOIN aisle f ON f.aisle_id = b.aisle_id INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND d.shelf_id =@shefId AND a.product_title LIKE ('%'+@strKey+'%')  ORDER BY a.product_title";

    public const string productListDetails3 = "SELECT a.product_id, a.product_title, a.product_size, a.product_image,a.product_image2,a.product_description, b.productlink_id, b.productlink_hide, b.productlink_buyprice, b.productlink_presale, b.productlink_buyprice, b.productlink_price, b.location_id, d.shelf_name, d.shelf_id, e.location_name,f.aisle_id,f.aisle_name FROM product a INNER JOIN productlink b ON b.product_id = a.product_id INNER JOIN aisle f ON f.aisle_id = b.aisle_id INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND a.product_title LIKE ('%'+@strKey+'%')  ORDER BY a.product_title";

    public const string productListDetailsnew5 = "SELECT a.product_id,a.product_title,a.product_size,a.product_description ,a.product_upc,a.product_image,a.product_image2,b.productlink_id, b.productlink_buyprice, b.productlink_presale,b.productlink_price,b.productlink_suggest,b.productlink_featured, b.location_id, d.shelf_name, d.shelf_id, e.location_name FROM product a INNER JOIN productlink b ON b.product_id = a.product_id  INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND d.shelf_id =@shefId and a.product_id =@strproduct ORDER BY a.product_title";
    
    public const string productList_Details = "SELECT a.product_upc, a.product_id, a.product_title, a.product_size As Size,a.product_description As description ,a.product_image, b.productlink_id, b.productlink_hide, b.productlink_buyprice, b.productlink_presale, b.productlink_buyprice, b.productlink_price, b.location_id, d.shelf_name, d.shelf_id, e.location_name FROM product a INNER JOIN productlink b ON b.product_id = a.product_id INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId ORDER BY a.product_title";

    public const string productListDetails_1 = "SELECT a.product_upc, a.product_id, a.product_title, a.product_size As Size,a.product_description As description, a.product_image, b.productlink_id, b.productlink_hide, b.productlink_buyprice, b.productlink_presale, b.productlink_buyprice, b.productlink_price, b.location_id, d.shelf_name, d.shelf_id, e.location_name FROM product a INNER JOIN productlink b ON b.product_id = a.product_id  INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND d.shelf_id =@shefId ORDER BY a.product_title";

    public const string productListDetails_2 = "SELECT a.product_upc, a.product_id, a.product_title, a.product_size As Size,a.product_description As description, a.product_image, b.productlink_id, b.productlink_hide, b.productlink_buyprice, b.productlink_presale, b.productlink_buyprice, b.productlink_price, b.location_id, d.shelf_name, d.shelf_id, e.location_name FROM product a INNER JOIN productlink b ON b.product_id = a.product_id  INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND d.shelf_id =@shefId AND (a.product_title LIKE ('%'+@strKey+'%') OR a.product_description LIKE ('%'+@strKey+'%')) ORDER BY a.product_title";

    public const string productListDetails_3 = "SELECT a.product_upc, a.product_id, a.product_title, a.product_size As Size,a.product_description As description ,a.product_image, b.productlink_id, b.productlink_hide, b.productlink_buyprice, b.productlink_presale, b.productlink_buyprice, b.productlink_price, b.location_id, d.shelf_name, d.shelf_id, e.location_name FROM product a INNER JOIN productlink b ON b.product_id = a.product_id  INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND d.shelf_id =@shefId AND (a.product_title LIKE ('%'+@strKey+'%')  OR a.product_description LIKE ('%'+@strKey+'%')) AND a.product_upc LIKE ('%'+@strUPC+'%')  ORDER BY a.product_upc";
    
    public const string deleteProductInfo = "delete from product where product_id=@intProductID";

    public const string deleteListadminInfo = "delete from list where list_id=@intListID";

    public const string deleteProductMappingInfo = "delete from productlink where product_id=@intProductID";

    public const string deleteListadminMappingInfo = "delete from listlink where list_id=@intListID";

    public const string selectProductNameInfo = "SELECT product_title,product_size FROM product where product_title=@productTitle and product_size=@size";


    public const string Checkordersnumber = "SELECT  *from orders where  orders_number=@orders_number";

    public const string CheckorderID = "SELECT  *from orders where  orders_id=@orders_id";

    public const string insertProductInfo = "insert into product(product_title,product_description,product_image,product_size,product_image2,product_comments,product_store)values(@title,@desc,@imgNm,@size,@imgNm1,@comment,@store); select @@identity";

    //  public const string asileListdetails = "SELECT top 1 aisle_id,shelf_id,aislelink_id FROM aislelink where shelf_id=@shefId";
    //new p
    public const string asileListDetails = "SELECT top 1 aisle_id,shelf_id,aislelink_id FROM aislelink where shelf_id=@shefId";

    public const string insertProductMappingInfo = "insert into productlink(location_id,product_id,shelf_id,aisle_id,aislelink_id,productlink_price,productlink_buyprice,productlink_presale,productlink_soda,productlink_suggest,productlink_tax,productlink_featured,productlink_hide)values(@locId,@productId,@shelfId,@asileId,@asileLink,@price,@buyPrice,@perSale,@soda,@suggest,@tax,@recomm,@hide)";

    public const string insertProductMappingInfo1 = "insert into productlink(location_id,product_id,shelf_id,aisle_id,aislelink_id,productlink_price,productlink_buyprice,productlink_soda,productlink_suggest,productlink_tax,productlink_featured,productlink_hide)values(@locId,@productId,@shelfId,@asileId,@asileLink,@price,@buyPrice,@soda,@suggest,@tax,@recomm,@hide)";
    public const string selectProductDetails_new1 = "select * from product_details_vw where product_id=@productId";

    public const string selectProductDetails = "select p.product_title,p.product_description,p.product_image,p.product_size,p.product_image2,p.product_comments,p.product_store,pl.location_id,pl.product_id,pl.shelf_id,pl.aisle_id,pl.aislelink_id,pl.productlink_price,pl.productlink_buyprice,pl.productlink_presale,pl.productlink_soda,pl.productlink_suggest,pl.productlink_tax,pl.productlink_featured,pl.productlink_hide,ProductType from  product p,productlink pl where p.product_id=@productId";

    public const string selectProductNameAlreadyExist = "SELECT product_title,product_size FROM product where product_title=@productTitle and product_size=@size and product_id!=@product";

    public const string updateProductInfo = "update product set product_title=@title,product_description=@desc,product_image=@imgNm,product_size=@size,product_image2=@imgNm1,product_comments=@comment,product_store=@store where product_id=@productId";

    public const string updateProductMappingInfo = "update productlink set productlink_price=@price,productlink_buyprice=@buyPrice,productlink_presale=@perSale,productlink_soda= @soda,productlink_suggest=@suggest,productlink_tax=@tax,productlink_featured=@recomm,productlink_hide=@hide where product_id=@productid";

    public const string updateProductMappingInfo1 = "update productlink set productlink_price=@price,productlink_buyprice=@buyPrice,productlink_presale=null,productlink_soda= @soda,productlink_suggest=@suggest,productlink_tax=@tax,productlink_featured=@recomm,productlink_hide=@hide where product_id=@productid";


    //Coupon Report  
    //public const string selectCouponReportsDetails = "SELECT convert(varchar,a.transactions_date,101) as date, a.transactions_amount, b.coupon_code, (c.users_lname+' '+c.users_fname) as userName, d.location_name FROM transactions a INNER JOIN coupon b ON b.coupon_id = a.coupon_id INNER JOIN users c ON c.users_id = a.users_id INNER JOIN location d ON d.location_id = c.location_id WHERE convert(varchar,a.transactions_date,101) >= @strStartDate AND convert(varchar,a.transactions_date,101) <= @strToDate AND c.location_id=@location AND a.coupon_id IS NOT NULL ORDER BY convert(varchar,a.transactions_date,101)";

    //public const string selectCouponReportsTotalDetails = "SELECT sum(a.transactions_amount) as totalAmt FROM transactions a INNER JOIN coupon b ON b.coupon_id = a.coupon_id INNER JOIN users c ON c.users_id = a.users_id INNER JOIN location d ON d.location_id = c.location_id WHERE convert(varchar,a.transactions_date,101) >= @strStartDate AND convert(varchar,a.transactions_date,101) <= @strToDate AND c.location_id=@location AND a.coupon_id IS NOT NULL";

    public const string selectCouponReportsDetails = "SELECT transactions_date,convert(varchar,a.transactions_date,101) as date, a.transactions_amount, b.coupon_code, (c.users_lname+' '+c.users_fname) as userName, d.location_name FROM transactions a INNER JOIN coupon b ON b.coupon_id = a.coupon_id INNER JOIN users c ON c.users_id = a.users_id INNER JOIN location d ON d.location_id = c.location_id WHERE a.transactions_date between @strStartDate AND @strToDate AND c.location_id=@location AND a.coupon_id IS NOT NULL ORDER BY a.transactions_date";

    public const string selectCouponReportsTotalDetails = "SELECT sum(a.transactions_amount) as totalAmt  FROM transactions a INNER JOIN coupon b ON b.coupon_id = a.coupon_id INNER JOIN users c ON c.users_id = a.users_id INNER JOIN location d ON d.location_id = c.location_id WHERE a.transactions_date between  @strStartDate AND @strToDate AND c.location_id=@location AND a.coupon_id IS NOT NULL";

    public const string selectCouponReportsDetails1 = "SELECT transactions_date,convert(varchar,a.transactions_date,101) as date, a.transactions_amount, b.coupon_code, (c.users_lname+' '+c.users_fname) as userName, d.location_name FROM transactions a INNER JOIN coupon b ON b.coupon_id = a.coupon_id INNER JOIN users c ON c.users_id = a.users_id INNER JOIN location d ON d.location_id = c.location_id WHERE convert(varchar,a.transactions_date,101) = @strStartDate  AND c.location_id=@location AND a.coupon_id IS NOT NULL ORDER BY a.transactions_date";

    public const string selectCouponReportsTotalDetails1 = "SELECT sum(a.transactions_amount) as totalAmt  FROM transactions a INNER JOIN coupon b ON b.coupon_id = a.coupon_id INNER JOIN users c ON c.users_id = a.users_id INNER JOIN location d ON d.location_id = c.location_id WHERE convert(varchar,a.transactions_date,101) = @strStartDate AND c.location_id=@location AND a.coupon_id IS NOT NULL";


    //Deleivery date 

    //public const string selectDeliveryDateDetails = "SELECT DISTINCT a.deliverydate_id,convert(varchar, b.deliverydate_date,101) as deliveryDate, c.location_name FROM deliverydatetime a INNER JOIN deliverydate b ON b.deliverydate_id = a.deliverydate_id INNER JOIN location c ON c.location_id = a.location_id WHERE (a.location_id = 1) order by convert(varchar, b.deliverydate_date,101) desc";

    //public const string selectDeliveryDateDetails = "SELECT DISTINCT a.deliverydate_id, CONVERT(varchar, b.deliverydate_date, 101) AS deliveryDate, c.location_name, Zone.zone FROM  deliverydatetime AS a INNER JOIN deliverydate AS b ON b.deliverydate_id = a.deliverydate_id INNER JOIN location AS c ON c.location_id = a.location_id INNER JOIN deliverydatezip ON b.deliverydate_id = deliverydatezip.deliverydate_id INNER JOIN Zone ON deliverydatezip.zone_id = Zone.zone_id WHERE (a.location_id = 1)ORDER BY deliveryDate DESC";
   // public const string selectDeliveryDateDetails = "SELECT DISTINCT a.deliverydate_id, CONVERT(varchar, b.deliverydate_date, 101) AS deliveryDate, c.location_name FROM deliverydatetime AS a INNER JOIN deliverydate AS b ON b.deliverydate_id = a.deliverydate_id INNER JOIN location AS c ON c.location_id = a.location_id INNER JOIN deliverydatezip ON b.deliverydate_id = deliverydatezip.deliverydate_id WHERE (a.location_id = 1) ORDER BY deliveryDate DESC";


    public const string selectDeliveryDateDetails = "SELECT DISTINCT a.deliverydate_id, CONVERT(varchar, b.deliverydate_date, 101) AS deliveryDate,CONVERT(varchar, b.deliverydate_date, 102) AS deliveryDate1, c.location_name FROM deliverydatetime AS a INNER JOIN deliverydate AS b ON b.deliverydate_id = a.deliverydate_id INNER JOIN location AS c ON c.location_id = a.location_id INNER JOIN deliverydatezip ON b.deliverydate_id = deliverydatezip.deliverydate_id WHERE (a.location_id = 1) ORDER BY deliveryDate1 DESC";


    public const string deleteDeliveryDate = "DELETE FROM deliverydate WHERE deliverydate_id=@intDeliveryID";

    public const string deleteDeliveryDateTime = "DELETE FROM deliverydatetime WHERE deliverydate_id=@intDeliveryID";

    public const string deleteDeliveryDateZip = "DELETE FROM deliverydatezip WHERE deliverydate_id=@intDeliveryID";

    public const string selectDeliverytimeInfo = "select  *  from deliverytime order by deliverytime_time";

   public const string selectZip = "select * from zipcode order by zipcode_zipcode asc";
    public const string selectZip_hide = "select * from zipcode where zipcode_hide!=1 or zipcode_hide is null order by zipcode_zipcode asc";
    //public const string selectZip = "SELECT zipcode.zipcode_id, zipcode.zipcode_zipcode, zipcode.location_id, zipcode.zipcode_name, zipcode.ZipOrderSize, zipcode.Zone, Zone.zone_id, Zone.zone AS Expr1 FROM zipcode INNER JOIN Zone ON zipcode.Zone = Zone.zone ORDER BY zipcode.zipcode_zipcode";


    public const string selectZone = "select * from Zone order by Zone asc";

    public const string insertDeliveryDateInfo = "insert into deliverydate(deliverydate_date,location_id,deliverydate_reminded)values(@deliveryDate,@intLocId,'0'); select @@identity";

    public const string insertDeliveryDateZipInfo = "insert into deliverydatezip(deliverydate_id,zipcode_id) values(@deliveryDateId,@zipcode_id)";

    public const string insertDeliveryDateMappingInfo = "insert into deliverydatetime(deliverydate_id,deliverytime_id,deliverydatetime_capacity,location_id)values(@deliveryDateId,@timeId,@intCapacity,@intLoc)";

    public const string selectDeliveryDateAlreadyExist = "select * from deliverydate where convert(varchar,deliverydate_date,101) =@strDate";

    //public const string selectDeliveryDateCapacityDetails = "SELECT convert(varchar, a.deliverydate_date,101) as deliverydate, c.deliverytime_time, c.deliverytime_cuttime, b.deliverydatetime_capacity FROM deliverydate a INNER JOIN deliverydatetime b ON b.deliverydate_id = a.deliverydate_id INNER JOIN deliverytime c ON c.deliverytime_id = b.deliverytime_id WHERE a.deliverydate_id =@deliveryId AND b.Zone = 1";
    public const string selectDeliveryDateCapacityDetails = "SELECT convert(varchar, a.deliverydate_date,101) as deliverydate, c.deliverytime_time, c.deliverytime_cuttime, b.deliverydatetime_capacity FROM deliverydate a INNER JOIN deliverydatetime b ON b.deliverydate_id = a.deliverydate_id INNER JOIN deliverytime c ON c.deliverytime_id = b.deliverytime_id WHERE a.deliverydate_id =@deliveryId";

    public const string selectDeliveryDateCapacityDetailsZone2 = "SELECT convert(varchar, a.deliverydate_date,101) as deliverydate, c.deliverytime_time, c.deliverytime_cuttime, b.deliverydatetime_capacity FROM deliverydate a INNER JOIN deliverydatetime b ON b.deliverydate_id = a.deliverydate_id INNER JOIN deliverytime c ON c.deliverytime_id = b.deliverytime_id WHERE a.deliverydate_id =@deliveryId AND b.Zone = 2";



    //Sales Item

    public const string selectHomePageInfo = "SELECT TOP 1 * FROM sale WHERE location_id =@locationId";

    public const string insertHomePageInfo = "insert into sale(sale_text,sale_limit,homepage_text,location_id,sale_price,homepage_text2,homepage_title2)values(@strHomePage,@strLimit,@strWelcomeTxt,@intLoc,@Price,homepage_text2,homepage_title2)";

    public const string updateHomePageInfo = "update sale set sale_text=@strHomePage,sale_limit=@strLimit,homepage_text=@strWelcomeTxt,location_id=@intLoc,sale_price=@Price,homepage_title2=@homepage_title2,homepage_text2=@homepage_text2 where sale_id=1";


    public const string salesItemListDetails = "SELECT a.product_id, a.product_title, b.productlink_price, b.productlink_id, a.product_size, b.productlink_presale, a.product_image, b.location_id from product a INNER JOIN productlink b ON b.product_id = a.product_id WHERE productlink_presale IS NOT NULL AND b.location_id =@locationId ";

    public const string updatePreSaleInformation = "update productlink set productlink_presale=null,productlink_price=@price where product_id=@productid";

    public const string updatePreSaleInformation1 = "update productlink set productlink_presale=null where product_id=@productid";

    public const string updateSaleInfo = "update productlink set productlink_presale=@preSale,productlink_price=@price where product_id=@productid";

    public const string updateSaleInfo1 = "update productlink set productlink_presale=null,productlink_price=@price where product_id=@productid";

    public const string updatelistprodqty = "update listlink set listlink_qty=@qty where list_id=@listid and product_id=@productid";

    public const string selectProductInformationDetails = " select p.product_id,p.product_title,p.product_size,pl.productlink_price,pl.productlink_presale from product p,productlink pl where p.product_id=pl.product_id and p.product_id=@productId";

    public const string updateProductSaleInfo = "update productlink set productlink_price=@Price,productlink_presale=@PrePrice where product_id=@intProductId";




    //Product Reports
    public const string ProductReportListDetails = "select * from sales_by_shelf_all(@strStartDate,@strToDate) ORDER BY quantity desc";

    public const string ProductReportListDetails1 = "select * from sales_by_shelf_all(@strStartDate,@strToDate) ORDER BY quantity asc";

    public const string ProductReportListDetailsNew = "select * from sales_by_shelf(@strStartDate,@strToDate,@intshelfid) ORDER BY quantity desc";

    public const string ProductReportListDetailsNew1 = "select * from sales_by_shelf(@strStartDate,@strToDate,@intshelfid) ORDER BY quantity asc";



    //Balance Reports


    public const string selectBalanceReportsDetails = "SELECT users.users_id, users.location_id, users.users_accountvalue, users.users_fname, users.users_lname, location.location_name FROM users INNER JOIN location ON location.location_id = users.location_id WHERE users.location_id =@locId AND users.users_accountvalue >@intBalAmt ORDER BY users.users_lname ASC";

    public const string selectBalanceReportsDetails1 = "SELECT users.users_id, users.location_id, users.users_accountvalue, users.users_fname, users.users_lname, location.location_name FROM users INNER JOIN location ON location.location_id = users.location_id WHERE users.location_id =@locId AND users.users_accountvalue >@intBalAmt ORDER BY users.users_accountvalue ASC";

    //public const string selectBalanceReportsdetailsInfo = "SELECT convert(varchar, transactions_date,101) as transactions_date ,transactions_amount,orders_id,transactions_comment from transactions where users_id = @userId ORDER BY convert(varchar, transactions_date,101)  desc";
  //  public const string selectBalanceReportsdetailsInfo = "SELECT CONVERT(varchar, dbo.transactions.transactions_date, 101) AS transactions_date, dbo.transactions.transactions_amount, dbo.transactions.orders_id, dbo.transactions.transactions_comment, dbo.orders.orders_number FROM dbo.transactions INNER JOIN dbo.orders ON dbo.transactions.orders_id = dbo.orders.orders_id WHERE (dbo.transactions.users_id = @userId) ORDER BY transactions_date DESC";
    public const string selectBalanceReportsDetailsInfo = "SELECT CONVERT(varchar, dbo.transactions.transactions_date, 101) AS transactions_date, dbo.transactions.transactions_amount, dbo.transactions.orders_id, dbo.transactions.transactions_comment, dbo.orders.orders_number FROM dbo.transactions left JOIN  dbo.orders ON dbo.transactions.orders_id = dbo.orders.orders_number WHERE (dbo.transactions.users_id = @userId) ORDER BY transactions_date DESC";




    //Home Page

    public const string selectHomeUserDetailInfo = "select Top 5 users_id,users_lname,users_fname,users_email,users_address1,convert(varchar, users_regdate,101) as date1 from users  order by convert(varchar, users_regdate,101) desc";

    public const string selectHomeOrderDetailInfo = "select Top 5 o.orders_id,o.orders_number,u.users_id,u.users_lname,u.users_fname,convert(varchar, o.orders_deliverydate,101) as deliverydate,o.orders_deliverytime,l.location_name from users u,orders o,location l where u.users_id=o.users_id and l.location_id=@locId  and convert(varchar, o.orders_deliverydate,101)>@strTodayDate";


    public const string selectHomeOrderDetailInfo1 = "select Top 5 o.orders_id,o.orders_number,u.users_id,u.users_lname,u.users_fname,convert(varchar, o.orders_deliverydate,101) as deliverydate,o.orders_deliverytime,l.location_name from users u,orders o,location l where u.users_id=o.users_id and l.location_id=@locId order by o.orders_id desc";


    public const string selectHomeUserInformation = "select * from users where users_id=@userId";


    //User
    public const string selectUserDetailInformationtest = "select *from users";

    public const string selectUserDetailInformation = "select a.users_id,a.users_estimate, a.users_fname, a.users_lname, a.users_email, convert(varchar ,a.users_regdate,101) as users_regdate, a.users_address1, a.users_hear, b.location_name,a.users_zip as orders from users a INNER JOIN location b on a.location_id = b.location_id WHERE  a.location_id =@locId ORDER BY a.users_lname";

    public const string selectUserDetailInformation1 = "select a.users_id,a.users_estimate, a.users_fname, a.users_lname, a.users_email,convert(varchar ,a.users_regdate,101) as users_regdate, a.users_address1, a.users_hear, b.location_name,a.users_zip as orders from users a INNER JOIN location b on a.location_id = b.location_id WHERE  a.location_id =@locId ORDER BY a.users_fname";

    public const string selectUserDetailInformation2 = "select a.users_id,a.users_estimate, a.users_fname, a.users_lname, a.users_email, convert(varchar ,a.users_regdate,101) as users_regdate, a.users_address1, a.users_hear, b.location_name,a.users_zip as orders from users a INNER JOIN location b on a.location_id = b.location_id WHERE  a.location_id =@locId ORDER BY a.users_regdate desc";

    public const string selectUserDetailInformation3 = "select a.users_id, a.users_estimate,a.users_fname, a.users_lname, a.users_email, convert(varchar ,a.users_regdate,101) as users_regdate, a.users_address1, a.users_hear, b.location_name,a.users_zip as orders from users a INNER JOIN location b on a.location_id = b.location_id WHERE a.users_lname LIKE ('%'+@strKey+'%') and  a.location_id =@locId ORDER BY a.users_lname";

    public const string selectUserDetailInformation4 = "select a.users_id, a.users_estimate,a.users_fname, a.users_lname, a.users_email,convert(varchar ,a.users_regdate,101) as users_regdate, a.users_address1, a.users_hear, b.location_name,a.users_zip as orders from users a INNER JOIN location b on a.location_id = b.location_id WHERE  a.users_lname LIKE ('%'+@strKey+'%') and a.location_id =@locId ORDER BY a.users_fname";

    public const string selectUserDetailInformation5 = "select a.users_id, a.users_estimate,a.users_fname, a.users_lname, a.users_email, convert(varchar ,a.users_regdate,101) as users_regdate, a.users_address1, a.users_hear, b.location_name,a.users_zip as orders from users a INNER JOIN location b on a.location_id = b.location_id WHERE  a.users_lname LIKE ('%'+@strKey+'%') and a.location_id =@locId ORDER BY a.users_regdate desc";

    public const string selectUserDetailInformation6 = "select a.users_id, a.users_estimate,a.users_fname, a.users_lname, a.users_email, convert(varchar ,a.users_regdate,101) as users_regdate, a.users_address1, a.users_hear, b.location_name,a.users_zip as orders from users a INNER JOIN location b on a.location_id = b.location_id WHERE a.users_fname LIKE ('%'+@strKey+'%') and  a.location_id =@locId ORDER BY a.users_lname";

    public const string selectUserDetailInformation7 = "select a.users_id, a.users_estimate,a.users_fname, a.users_lname, a.users_email,convert(varchar ,a.users_regdate,101) as users_regdate, a.users_address1, a.users_hear, b.location_name,a.users_zip as orders from users a INNER JOIN location b on a.location_id = b.location_id WHERE  a.users_fname LIKE ('%'+@strKey+'%') and a.location_id =@locId ORDER BY a.users_fname";

    public const string selectUserDetailInformation8 = "select a.users_id, a.users_estimate,a.users_fname, a.users_lname, a.users_email, convert(varchar ,a.users_regdate,101)as users_regdate , a.users_address1, a.users_hear, b.location_name,a.users_zip as orders from users a INNER JOIN location b on a.location_id = b.location_id WHERE  a.users_fname LIKE ('%'+@strKey+'%') and a.location_id =@locId ORDER BY a.users_regdate desc";

    public const string selectUserOrderCount = "select count(o.orders_id) as orderCnt from users a ,orders o  WHERE  a.users_id=@userId and a.users_id = o.users_id";

    public const string selectUserOrderDetailInformation = "select orders_id,orders_number,(convert(varchar,orders_deliverydate,101)+' at '+orders_deliverytime) as delivery ,orders_totalfinal,(convert(varchar,orders_datetime,101)+' '+CONVERT(CHAR(8),orders_datetime,8))as ordered from orders WHERE users_id =@userId";

    public const string selectUserProductDetailInformation = "SELECT orderproduct.product_id, orderproduct.orderproduct_price, product.product_title, sum(orderproduct.orderproduct_quantity) AS crap  FROM orderproduct INNER JOIN product ON orderproduct.product_id = product.product_id  INNER JOIN orders ON orders.orders_id = orderproduct.orders_id WHERE orders.users_id =@userId GROUP BY orderproduct.product_id,product.product_title,orderproduct.orderproduct_price";

    public const string selectUserOrderDetail = "select orders_id,orders_address,orders_address2,orders_city,orders_state,orders_zip,orders_number,(convert(varchar,orders_deliverydate,101)+' at '+orders_deliverytime) as delivery ,orders_totalfinal,(convert(varchar,orders_datetime,101)+' '+CONVERT(CHAR(8),orders_datetime,8)) as ordered,orders_paymenttype,orders_complimentary,orders_instructions,orders_grocerytotal,orders_tax,orders_tax2,orders_sodadeposit,orders_deliveryfee,orders_tip,orders_GroceriesTax,orders_complimentary  from orders WHERE users_id =@userId and orders_id=@orderId";
    public const string selectTrascDetails = "select *from transactions Where orders_id=@orders_id and users_id=@users_id";

    public const string selectTrascordersnumberDetails = "select *from transactions Where orders_id=@orders_number and users_id=@users_id";

    public const string selectUserProductDetail = "select * from orderproduct INNER JOIN product ON product.product_id = orderproduct.product_id WHERE orders_id =@orderId order by  product_title asc";

    public const string selectEmailAlreadyExist = "select * from users where users_email=@email and users_id!=@intUserId";

    public const string updateUserInformation = "update users set users_fname=@fName,users_lname=@lName,users_phone=@phn,users_email=@email,users_cell=@cell,users_address1=@address1,users_address2=@address2,users_city=@city,users_state=@state,users_zip=@zip,users_password=@pwd,users_baddress1=@bAddress1,users_baddress2=@bAddress2,users_bcity=@bCity,users_bstate=@bState,users_bzip=@bZip,users_newsletter=@chkMail,usersstatus_id=@status where users_id=@intUserId";

    public const string updateUserInformation1 = "update users set users_fname=@fName,users_lname=@lName,users_phone=@phn,users_email=@email,users_cell=@cell,users_address1=@address1,users_address2=@address2,users_city=@city,users_state=@state,users_zip=@zip,users_password=@pwd,users_baddress1=@bAddress1,users_baddress2=@bAddress2,users_bcity=@bCity,users_bstate=@bState,users_bzip=@bZip,users_newsletter=@chkMail,users_Membership=@chkMember,usersstatus_id=@status where users_id=@intUserId";

    //Depositors

    public const string selectDepositorsDetailInformation = "SELECT a.parent_id, a.parent_fname, a.parent_lname, a.parent_email,(b.users_lname +' '+ b.users_fname) as customer, c.location_name FROM parent a INNER JOIN users b ON b.users_id = a.users_id INNER JOIN location c ON c.location_id = b.location_id WHERE b.location_id =@locId ORDER BY a.parent_lname, a.parent_fname";

    public const string selectDepositorsDetailInformation1 = "SELECT a.parent_id, a.parent_fname, a.parent_lname, a.parent_email, (b.users_lname +' '+ b.users_fname) as customer, c.location_name FROM parent a INNER JOIN users b ON b.users_id = a.users_id INNER JOIN location c ON c.location_id = b.location_id AND a.parent_lname LIKE ('%'+@strKey+'%') WHERE b.location_id =@locId ORDER BY a.parent_lname, a.parent_fname";

    public const string selectTransactionDetails = "SELECT convert(varchar,a.transactions_date,101) as transactions_date, a.transactions_fname, a.transactions_lname, a.transactions_address, a.transactions_address2, a.transactions_city, a.transactions_state, a.transactions_zip, a.transactions_amount, a.transactions_phone, a.transactions_creditcard, a.transactions_expiration, b.users_fname, b.users_lname FROM transactions a INNER JOIN users b ON b.users_id = a.users_id WHERE a.parent_id =@intParentId  ORDER BY a.transactions_date DESC";


    //Transactions

    public const string selectCustomerTransactionDetail = "SELECT a.transactions_id, a.transactions_amount, a.users_id, convert(varchar,a.transactions_date,101) as transactions_date, a.coupon_id, c.location_name,( b.users_lname +' ' + b.users_fname) as users, d.coupon_code FROM transactions a INNER JOIN users b ON a.users_id = b.users_id INNER JOIN location c ON c.location_id = b.location_id LEFT JOIN coupon d ON d.coupon_id = a.coupon_id WHERE b.location_id=@locId ORDER BY a.transactions_date DESC";

    public const string selectCustTransactionDetailsIfo = "select convert(varchar,a.transactions_date,101) as transactions_date,( b.users_lname +' ' + b.users_fname) as users,a.transactions_amount,a.transactions_comment,a.transactions_fname,a.transactions_lname,a.transactions_address,a.transactions_address2,a.transactions_address3,a.transactions_city,a.transactions_state,a.transactions_zip,a.transactions_phone,a.orders_id from transactions a INNER JOIN users b on a.users_id=b.users_id WHERE transactions_id =@intTransId ";

    public const string insertTransactionInformation = "insert into transactions(transactions_date,transactions_amount,transactions_comment,users_id) values(@dtToday,@amt,@comment,@intUserId)";

    public const string insertTransactionInformation1 = "insert into transactions(transactions_date,transactions_amount,transactions_comment,users_id,orders_id) values(@dtToday,@amt,@comment,@intUserId,@orderId)";

    public const string selectAccountInformation = "SELECT users_accountvalue FROM users WHERE users_id =@intuserId";

    public const string updateTransactionInfo = "update users set users_accountvalue=@account where users_id=@intUserId";


    //Saved list product reports

    public const string selectSavedProductListReports = "SELECT g.list_type, a.product_id, c.productlink_price, b.product_title, SUM(a.listlink_qty) AS crap FROM listlink a INNER JOIN product b ON a.product_id = b.product_id INNER JOIN productlink c ON c.product_id = b.product_id INNER JOIN list g ON g.list_id = a.list_id WHERE g.list_type = 1 AND g.location_id =@intLoc GROUP BY a.product_id, b.product_title, c.productlink_price, g.list_type ORDER BY crap DESC";

    public const string selectSavedProductListReports1 = "SELECT g.list_type, a.product_id, c.productlink_price, b.product_title, SUM(a.listlink_qty) AS crap FROM listlink a INNER JOIN product b ON a.product_id = b.product_id INNER JOIN productlink c ON c.product_id = b.product_id INNER JOIN list g ON g.list_id = a.list_id WHERE g.list_type = 1 AND g.location_id =@intLoc GROUP BY a.product_id, b.product_title, c.productlink_price, g.list_type ORDER BY crap ASC";

    public const string selectSavedProductReports = "SELECT TOP 10 g.list_type, a.product_id, c.productlink_price, b.product_title, SUM(a.listlink_qty) AS crap FROM listlink a INNER JOIN product b ON a.product_id = b.product_id INNER JOIN productlink c ON c.product_id = b.product_id INNER JOIN list g ON g.list_id = a.list_id WHERE g.list_type = 1 AND g.location_id =@intLoc GROUP BY a.product_id, b.product_title, c.productlink_price, g.list_type ORDER BY crap DESC";

    public const string selectSavedProductReports1 = "SELECT TOP 50 g.list_type, a.product_id, c.productlink_price, b.product_title, SUM(a.listlink_qty) AS crap FROM listlink a INNER JOIN product b ON a.product_id = b.product_id INNER JOIN productlink c ON c.product_id = b.product_id INNER JOIN list g ON g.list_id = a.list_id WHERE g.list_type = 1 AND g.location_id =@intLoc GROUP BY a.product_id, b.product_title, c.productlink_price, g.list_type ORDER BY crap DESC";

    public const string selectSavedProductReports2 = "SELECT TOP 100 g.list_type, a.product_id, c.productlink_price, b.product_title, SUM(a.listlink_qty) AS crap FROM listlink a INNER JOIN product b ON a.product_id = b.product_id INNER JOIN productlink c ON c.product_id = b.product_id INNER JOIN list g ON g.list_id = a.list_id WHERE g.list_type = 1 AND g.location_id =@intLoc GROUP BY a.product_id, b.product_title, c.productlink_price, g.list_type ORDER BY crap DESC";

    public const string selectSavedProductList = "SELECT TOP 10 g.list_type, a.product_id, c.productlink_price, b.product_title, SUM(a.listlink_qty) AS crap FROM listlink a INNER JOIN product b ON a.product_id = b.product_id INNER JOIN productlink c ON c.product_id = b.product_id INNER JOIN list g ON g.list_id = a.list_id WHERE g.list_type = 1 AND g.location_id =@intLoc GROUP BY a.product_id, b.product_title, c.productlink_price, g.list_type ORDER BY crap ASC";

    public const string selectSavedProductList1 = "SELECT TOP 50 g.list_type, a.product_id, c.productlink_price, b.product_title, SUM(a.listlink_qty) AS crap FROM listlink a INNER JOIN product b ON a.product_id = b.product_id INNER JOIN productlink c ON c.product_id = b.product_id INNER JOIN list g ON g.list_id = a.list_id WHERE g.list_type = 1 AND g.location_id =@intLoc GROUP BY a.product_id, b.product_title, c.productlink_price, g.list_type ORDER BY crap ASC";

    public const string selectSavedProductList2 = "SELECT TOP 100 g.list_type, a.product_id, c.productlink_price, b.product_title, SUM(a.listlink_qty) AS crap FROM listlink a INNER JOIN product b ON a.product_id = b.product_id INNER JOIN productlink c ON c.product_id = b.product_id INNER JOIN list g ON g.list_id = a.list_id WHERE g.list_type = 1 AND g.location_id =@intLoc GROUP BY a.product_id, b.product_title, c.productlink_price, g.list_type ORDER BY crap ASC";

    public const string selectSavedUserListReports = "SELECT a.list_name, a.list_id, b.location_id as TotalItem,(b.users_lname +' ' +b.users_fname) as UserName FROM list a INNER JOIN users b ON b.users_id = a.users_id WHERE a.list_type = 1 AND b.location_id =@intLoc  ORDER BY a.list_name ASC";

    public const string selectSavedUserListReports1 = "SELECT a.list_name, a.list_id, b.location_id as TotalItem,(b.users_lname +' ' +b.users_fname) as UserName FROM list a INNER JOIN users b ON b.users_id = a.users_id WHERE a.list_type = 1 AND b.location_id =@intLoc  ORDER BY b.users_lname ASC";

    public const string selectGetSavedTotalReports = "SELECT sum(listlink.listlink_qty) AS itemnumber FROM listlink WHERE listlink.list_id =@intListId ";

    public const string selectSavedListProductInfo = "SELECT a.list_name, b.listlink_qty, c.product_title, c.product_image, c.product_size, d.productlink_price FROM list a INNER JOIN listlink b ON b.list_id = a.list_id INNER JOIN product c ON c.product_id = b.product_id INNER JOIN productlink d ON d.product_id = c.product_id WHERE a.list_id =@intListId AND d.location_id =@intLoc";


    //Delivery Shedule 

    public const string selectDeliverySheduleDetails = "SELECT a.orders_id, a.orders_number, a.orders_deliverytime, Convert(VarChar,a.orders_deliverydate,101), a.orders_deliveryfee, a.orders_paymenttype,  a.orders_complimentary, b.users_id,(b.users_lname+' '+b.users_fname) as customer, a.orders_address, a.orders_tip, a.orders_tax,a.orders_tax2, a.orders_grocerytotal, a.orders_totalfinal FROM orders a INNER JOIN users b ON a.users_id = b.users_id  WHERE Convert(VarChar,a.orders_deliverydate,101) =@date   AND b.location_id =@locId  ORDER BY a.orders_deliverytime";

    public const string updateDeliverySheduleDetails = "update orders set orders_grocerytotal=@groceries,orders_deliveryfee=@deliveryfee,orders_tax=@tax,orders_tax2=@tax2,orders_tip=@tip,orders_totalfinal=@total,orders_complimentary=@charge where orders_id=@intOrderID";


    //order report

   // public const string selectOrderReportList = "SELECT convert(varchar,a.orders_deliverydate,101) as ordDate ,(b.users_lname+' '+ b.users_fname) as customer, c.location_name, a.orders_grocerytotal, a.orders_tip, a.orders_tax,a.orders_tax2, a.orders_deliveryfee, a.orders_totalfinal FROM orders a INNER JOIN users b ON b.users_id = a.users_id INNER JOIN location c ON c.location_id = b.location_id WHERE convert(varchar,a.orders_deliverydate,101) between @strStartDate AND @strToDate AND b.location_id = @locId ORDER BY convert(varchar,a.orders_deliverydate,101)";
    //public const string selectOrderReportList = "SELECT case when transactions_amount<0 then Sum(ABS(transactions_amount)) else 0  end as transactions_amount , convert(varchar,a.orders_deliverydate,101) as ordDate ,b.users_id,(b.users_lname+' '+ b.users_fname) as customer, c.location_name, a.orders_grocerytotal, a.orders_tip, a.orders_tax,a.orders_tax2, a.orders_deliveryfee, a.orders_totalfinal FROM orders a left join transactions t on t.orders_id=a.orders_id  INNER JOIN users b ON b.users_id = a.users_id INNER JOIN location c ON c.location_id = b.location_id WHERE   a.orders_deliverydate  between @strStartDate AND @strToDate AND b.location_id = @locId group by transactions_amount,orders_deliverydate,(b.users_lname+' '+ b.users_fname),location_name,orders_grocerytotal,orders_tip,orders_tax,orders_tax2,orders_deliveryfee,orders_totalfinal,b.users_id  ORDER BY  a.orders_deliverydate";  
   // public const string selectOrderReportList = " SELECT case when T.transactions_amount<0 then  (ABS(T.transactions_amount)) else 0  end as transactions_amount,convert(varchar,a.orders_deliverydate,101) as ordDate ,(b.users_lname+' '+ b.users_fname) as customer,c.location_name, a.orders_grocerytotal, a.orders_tip, a.orders_tax,a.orders_tax2, a.orders_deliveryfee, a.orders_totalfinal FROM orders a left join  (select o.orders_id ,t.transactions_amount from orders o ,transactions t  where o.orders_id=t.orders_id and transactions_amount<0 and o.orders_paymenttype='AF-CC' ) T on T.orders_id=a.orders_id INNER JOIN users b ON b.users_id = a.users_id INNER JOIN location c ON c.location_id = b.location_id WHERE  a.orders_deliverydate between @strStartDate AND @strToDate AND b.location_id = @locId  ORDER BY  a.orders_deliverydate ";

    public const string selectOrderReportList = " SELECT case when T.transactions_amount<0 then  (ABS(T.transactions_amount)) else 0  end as transactions_amount,convert(varchar,a.orders_deliverydate,101) as ordDate ,(b.users_lname+' '+ b.users_fname) as customer,c.location_name, a.orders_grocerytotal, a.orders_tip, a.orders_tax,a.orders_tax2, a.orders_deliveryfee, a.orders_totalfinal FROM orders a left join  (select o.orders_id ,t.transactions_amount ,t.users_id from orders o ,transactions t  where o.orders_id=t.orders_id and transactions_amount<0 and o.orders_paymenttype='AF-CC' ) T on T.orders_id=a.orders_id and T.users_id=a.users_id INNER JOIN users b ON b.users_id = a.users_id INNER JOIN location c ON c.location_id = b.location_id WHERE  a.orders_deliverydate between @strStartDate AND @strToDate AND b.location_id = @locId   group by a.orders_id,T.transactions_amount,a.orders_deliverydate,users_lname,users_fname,c.location_name, a.orders_grocerytotal, a.orders_tip, a.orders_tax,a.orders_tax2, a.orders_deliveryfee, a.orders_totalfinal ORDER BY  a.orders_deliverydate   ";

 
  
   // public const string selectTaxReportList = "SELECT convert(varchar,a.orders_deliverydate,101) as ordDate ,(b.users_lname+' '+ b.users_fname) as customer, c.location_name, a.orders_grocerytotal, a.orders_tip, a.orders_tax, a.orders_deliveryfee, a.orders_totalfinal,a.orders_id FROM orders a INNER JOIN users b ON b.users_id = a.users_id INNER JOIN location c ON c.location_id = b.location_id WHERE convert(varchar,a.orders_deliverydate,101) between @strStartDate AND @strToDate AND b.location_id = @locId ORDER BY convert(varchar,a.orders_deliverydate,101)";
    public const string selectTaxReportList = "SELECT convert(varchar,a.orders_deliverydate,101) as ordDate ,(b.users_lname+' '+ b.users_fname) as customer,c.location_name, a.orders_grocerytotal, a.orders_tip, a.orders_tax, a.orders_deliveryfee, a.orders_totalfinal,a.orders_id,a.orders_tax,a.orders_GroceriesTax,a.totfood,a.totnonfood,a.tax_food,a.tax_nonfood,a.total_tax FROM orders a INNER JOIN users b ON b.users_id = a.users_id INNER JOIN location c ON c.location_id = b.location_id WHERE convert(varchar,a.orders_deliverydate,101) between @strStartDate AND @strToDate AND b.location_id = @locId ORDER BY convert(varchar,a.orders_deliverydate,101)";
    //order

    public const string selectOrderListInfo = " select o.orders_id,u.users_id,o.orders_number,convert(varchar,o.orders_deliverydate,101)as delDate,o.orders_deliverytime,u.users_fname,u.users_lname,l.location_name from location l,users u,orders o  WHERE u.users_id=o.users_id and  l.location_id=u.location_id  and convert(varchar,o.orders_datetime,101) >= @strStartDate   AND convert(varchar,o.orders_datetime,101) <= @strToDate and u.location_id=@locId order by o.orders_id desc";

    public const string selectOrderListInfo1 = " select o.orders_id,u.users_id,o.orders_number,convert(varchar,o.orders_deliverydate,101)as delDate,o.orders_deliverytime,u.users_fname,u.users_lname,l.location_name from location l,users u,orders o  WHERE u.users_id=o.users_id and  l.location_id=u.location_id  and convert(varchar,o.orders_deliverydate,101) >= @strStartDate   AND convert(varchar,o.orders_deliverydate,101) <= @strToDate and u.location_id=@locId order by o.orders_id desc";

    public const string selectOrderListInfo2 = " select o.orders_id,u.users_id,o.orders_number,convert(varchar,o.orders_deliverydate,101)as delDate,o.orders_deliverytime,u.users_fname,u.users_lname,l.location_name from location l,users u,orders o  WHERE u.users_id=o.users_id and  l.location_id=u.location_id  and o.orders_number LIKE ('%'+@OrderNum+'%') and u.location_id=@locId order by o.orders_id desc";

    public const string selectOrderListInfo3 = " select o.orders_id,u.users_id,o.orders_number,convert(varchar,o.orders_deliverydate,101)as delDate,o.orders_deliverytime,u.users_fname,u.users_lname,l.location_name from location l,users u,orders o  WHERE u.users_id=o.users_id and  l.location_id=u.location_id  and u.location_id=@locId order by o.orders_id desc";

    public const string deleteOrder = "DELETE FROM orders WHERE orders_id=@intOrderID";


    public const string deleteproductOrder1 = "DELETE FROM orderproduct WHERE product_id=@intProductID and orders_id=@orderid";



    public const string deleteOrderProduct = "DELETE FROM orderproduct WHERE orders_id=@intOrderID";

    public const string updateOrderInfo = "update orders set orders_deliverydate=@Date,orders_deliverytime=@strTime where orders_id=@intOrderID";

    public const string updateTimeInfo = "update orders set orders_deliverytime=@strTime where orders_id=@intOrderID";
    public const string updateNewOrdertotals = "update orders set orders_deliveryfee=@orders_deliveryfee,orders_totalfinal=@orders_totalfinal,orders_grocerytotal=@orders_grocerytotal,orders_sodadeposit=@orders_sodadeposit,orders_tax=@orders_tax,orders_tax2=@orders_tax2,orders_complimentary=@orders_complimentary where orders_id=@orders_id";
    public const string updateProductOrderInfo1 = "update orderproduct set orderproduct_quantity=@txtTotalProductQty,orderproduct_price=@txtTotalProductPrice,orderproduct_edit=1 where product_id=@intProductID and orders_id=@orderId";
    public const string updateCommentInfo1 = "update orders set orders_instructions=@comment where orders_id=@orderId";

    public const string insertProductOrderInfo1_new = "insert into orderproduct(orders_id,product_id,orderproduct_quantity,orderproduct_price,orderproduct_edit) values(@orderId,@productId,@qty,@price,@orderproduct_edit)";
    public const string checknewproduct = "select *from orderproduct where  orders_id=@orders_id and product_id=@product_id ";
    
    //News letter sales

    public const string selectSalesDetails = "SELECT top 8 a.product_id, a.product_title, b.productlink_price, b.productlink_id, a.product_size, b.productlink_presale, a.product_image, b.location_id,b.shelf_id,b.aisle_id from product a INNER JOIN productlink b ON b.product_id = a.product_id WHERE productlink_presale IS NOT NULL AND b.location_id =@locationId ";

    public const string selectPreviewDetails = "select * from NewsPreview";

    public const string selectSalesDetails1 = "SELECT  a.product_id, a.product_title, b.productlink_price, b.productlink_id, a.product_size, b.productlink_presale, a.product_image, b.location_id,b.shelf_id,b.aisle_id from product a INNER JOIN productlink b ON b.product_id = a.product_id WHERE productlink_presale IS NOT NULL AND b.location_id =@locationId and a.product_id=@productid ";

    public const string insertPreviewInfo = "insert into NewsPreview(Subject,StarDate,EndDate,HeaderMsg,FooterMsg,locationId,Prod1,Prod2,Prod3,Prod4,Prod5,Prod6,Prod7,Prod8) values(@subject,@strStartDate,@strToDate,@strHead,@strFoot,@intLoc,@prod1,@prod2,@prod3,@prod4,@prod5,@prod6,@prod7,@prod8)";

    public const string updatePreviewInfo = "update NewsPreview set Subject=@subject,StarDate=@strStartDate,EndDate=@strToDate,HeaderMsg=@strHead,FooterMsg=@strFoot,locationId=@intLoc,Prod1=@prod1,Prod2=@prod2,Prod3=@prod3,Prod4=@prod4,Prod5=@prod5,Prod6=@prod6,Prod7=@prod7,Prod8=@prod8 where PreviewId=@previewId";

    public const string selectFeatureSalesDetails = "SELECT TOP 8 a.product_id,a.product_title, b.productlink_price, a.product_size, b.productlink_featured, a.product_image, b.location_id, c.aisle_id, c.shelf_id FROM product a INNER JOIN productlink b ON b.product_id = a.product_id INNER JOIN aislelink c ON c.aislelink_id = b.aislelink_id WHERE b.productlink_featured = 1 AND b.location_id =@locationId";

    public const string selectSubject = "select * from NewsPreview where PreviewId=1";



    //New Added Edit News letter sales

    public const string selectSendEmailInformation = "select * from NewSaleSendInfo where NewSaleSendId=@intSendEmailId";

    public const string selectSendEmailProductInfo = "SELECT a.product_id, a.product_title, b.productlink_price, b.productlink_id, a.product_size, b.productlink_presale, a.product_image, b.location_id,b.shelf_id,b.aisle_id from product a INNER JOIN productlink b ON b.product_id = a.product_id WHERE a.product_id=@intProductId and a.product_title=@prodTitle AND b.location_id =@locationId";

    public const string selectdsSendEmailDetails = "select NewSaleSendId,Subject,(StarDate+' to '+EndDate) as ForDate,convert(varchar,MailSendDate,101) as SendDate from NewSaleSendInfo order by NewSaleSendId desc";

    public const string deleteSendEmailDetails = "delete from NewSaleSendInfo where NewSaleSendId=@intID ";

    public const string insertEmailInfo = "INSERT INTO NewSaleSendInfo(Subject,StarDate,EndDate,HeaderMsg,FooterMsg,locationId,ProductSale1,ProductSaleTitle1,ProductSale2,ProductSaleTitle2,ProductSale3,ProductSaleTitle3,ProductSale4,ProductSaleTitle4,ProductSale5,ProductSaleTitle5,ProductSale6,ProductSaleTitle6,ProductSale7,ProductSaleTitle7,ProductSale8,ProductSaleTitle8,FeatureProduct1,FeatureProductTitle1,FeatureProduct2,FeatureProductTitle2,FeatureProduct3,FeatureProductTitle3,FeatureProduct4,FeatureProductTitle4,FeatureProduct5,FeatureProductTitle5,FeatureProduct6,FeatureProductTitle6,FeatureProduct7,FeatureProductTitle7,FeatureProduct8,FeatureProductTitle8,MailSendDate)VALUES(@subject,@strStartDate,@strToDate,@strHead,@strFoot,@intLoc,@prod1,@prodTit1,@prod2,@prodTit2,@prod3,@prodTit3,@prod4,@prodTit4,@prod5,@prodTit5,@prod6,@prodTit6,@prod7,@prodTit7,@prod8,@prodTit8,@feat1,@featTit1,@feat2,@featTit2,@feat3,@featTit3,@feat4,@featTit4,@feat5,@featTit5,@feat6,@featTit6,@feat7,@featTit7,@feat8,@featTit8,@dateToday)";

    public const string selectSalesDetailsInformation = "SELECT a.product_id, a.product_title, b.productlink_price, b.productlink_id, a.product_size, b.productlink_presale, a.product_image, b.location_id,b.shelf_id,b.aisle_id from product a INNER JOIN productlink b ON b.product_id = a.product_id WHERE productlink_presale IS NOT NULL AND b.location_id =@locationId ";

    public const string SelectSendEmailProductInformation = "SELECT a.product_id, a.product_title, b.productlink_price, b.productlink_id, a.product_size, b.productlink_presale, a.product_image, b.location_id,b.shelf_id,b.aisle_id from product a INNER JOIN productlink b ON b.product_id = a.product_id WHERE a.product_id=@intProductId  AND b.location_id =@locationId";



    //New added

    // public const string selectUserReportInfo = "select users_id,(users_fname+' '+users_lname)as userName,users_email,users_address1,users_city,users_state,users_zip,users_phone,convert(varchar, users_regdate,101) as date1 from users  order by convert(varchar, users_regdate,101) desc";


    /***** Shashank *******/


    //Zip code Admin 

    public const string selectZipCode = "SELECT * FROM zipcode INNER JOIN location ON location.location_id = zipcode.location_id ORDER BY zipcode_zipcode DESC";

    public const string deletZipCode = "DELETE FROM zipcode WHERE zipcode_id=@zipcode_id";

    public const string getLocation = "select * from location";

    //public const string insertZipCode = "insert into zipcode (zipcode_zipcode,location_id,zipcode_name) values(@zipcode_zipcode,@location_id,@zipcode_name)";
    public const string insertZipCode = "insert into zipcode (zipcode_zipcode,location_id,zipcode_name,ZipOrderSize) values(@zipcode_zipcode,@location_id,@zipcode_name,@ordSize)";
    public const string insertZipCode_hide = "insert into zipcode (zipcode_zipcode,location_id,zipcode_name,ZipOrderSize,zipcode_hide) values(@zipcode_zipcode,@location_id,@zipcode_name,@ordSize,@zipcode_hide)";
  
    public const string checkZipAvalable = "select * from zipcode where zipcode_zipcode=@zipcode_zipcode and zipcode_id!=@zipCodeId";

    public const string checkZipAddAvalable = "select * from zipcode where zipcode_zipcode=@zipcode_zipcode";

    public const string selectZipCodeForUpdate = "select * FROM zipcode WHERE zipcode_id=@zipcode_id";

    //public const string updateZipCode = "UPDATE zipcode SET zipcode_zipcode=@zipcode_zipcode , location_id=@location_id , zipcode_name=@zipcode_name where zipcode_id=@zipcode_id";
  public const string updateZipCode = "UPDATE zipcode SET zipcode_zipcode=@zipcode_zipcode , location_id=@location_id , zipcode_name=@zipcode_name,ZipOrderSize=@orderSize where zipcode_id=@zipcode_id";
  public const string updateZipCode_hide = "UPDATE zipcode SET zipcode_zipcode=@zipcode_zipcode , location_id=@location_id , zipcode_name=@zipcode_name,ZipOrderSize=@orderSize, zipcode_hide=@zipcode_hide where zipcode_id=@zipcode_id";
    // Shopping Cart constant.

    public const string selectShoppingCartConstant = "select * from shoppingcartvariables where ConstantId=1";

    public const string updateShoppingCartConstant = "UPDATE shoppingcartvariables SET DeliveryFee=@DeliveryFee , TaxRate_Food=@TaxRate ,TaxRate_NonFood=@TaxRate1,MinimumDeposit=@MinimumDeposit ,Numberoftimeslot=@Numberoftimeslot , DeliveryFeeCutOff=@DeliveryFeeCutOff , CustomerServiceEmail=@CustomerServiceEmail , ContactEmail=@ContactEmail , InfoEmail=@InfoEmail , LocationName=@LocationName , StateShortName=@StateShortName , StateLongName=@StateLongName , CompanyShortName=@CompanyShortName , CompanyLongName=@CompanyLongName ,  ShortURL=@ShortURL, LongURL=@LongURL, FirstOrderGift=@FirstOrderGift where ConstantId=@ConstantId";

    public const string updateShoppingCartConstantNew = "UPDATE shoppingcartvariables SET DeliveryFee=@DeliveryFee ,MemberDeliveryFee=@MemberDeliveryFee , TaxRate_Food=@TaxRate ,TaxRate_NonFood=@TaxRate1,MinimumDeposit=@MinimumDeposit ,Numberoftimeslot=@Numberoftimeslot , DeliveryFeeCutOff=@DeliveryFeeCutOff , CustomerServiceEmail=@CustomerServiceEmail , ContactEmail=@ContactEmail , InfoEmail=@InfoEmail , LocationName=@LocationName , StateShortName=@StateShortName , StateLongName=@StateLongName , CompanyShortName=@CompanyShortName , CompanyLongName=@CompanyLongName ,  ShortURL=@ShortURL, LongURL=@LongURL, FirstOrderGift=@FirstOrderGift where ConstantId=@ConstantId";

    public const string updateLocationName = "update location set location_name=@location_name where location_id=@location_id";

    public const string selectCompanyName = "select * from shoppingcartvariables";

    // Newsletter Text

    public const string selectInfoEmailAddressConstant = "select InfoEmail from shoppingcartvariables where ConstantId=1";

    public const string selectUserExmailAddress = "SELECT users_fname, users_email, location_id from users WHERE usersstatus_id =@usersstatus_id AND users_newsletter =@users_newsletter";

    // Payment option
    public const string selectPaymentOptions = "select * from payment_options_master";

    public const string selectPaymentOptionsForDisplay = "select * from paymnet_options_mapping where payment_option_Id=@payment_option_Id";



    // public const string updatePaymentOption = "update paymnet_options_mapping set payment_Id=@payment_Id where payment_option_Id=@payment_option_Id";

    public const string updatePaymentOption = "update paymnet_options_mapping set payment_Id=@payment_Id,API_Login=@APILogin,API_TransKey=@TranKey,API_PostUrl=@PostUrl where payment_option_Id=@payment_option_Id";

    public const string updatePaymentOption1 = "update paymnet_options_mapping set payment_Id=@payment_Id,API_PayPalEndPoint=@EndPayUrl,API_PayPalUserName=@PayUserNm,API_PayPalPassword=@PayPwd,API_PayPalSignature=@PaySignature,PAYPAL_EC_URL=@ECURL,ECURLLOGIN=@ECURLLOGIN where payment_option_Id=@payment_option_Id";

    public const string updatePaymentOptionNew1 = "update paymnet_options_mapping set payment_Id=@payment_Id,PaypalUrl=@PayUrl,PaypalEmail=@busEmail,PaypalSubUrl=@subUrl,PDTToken=@PdtToken where payment_option_Id=@payment_option_Id";


    public const string selectDeliveryRemindersDate = "SELECT DISTINCT Convert(VarChar,deliverydate_date,101) as deliverydate_date FROM deliverydate WHERE (deliverydate_date >= DATEADD(d, - 1, GETDATE())) ORDER BY deliverydate_date DESC";

    public const string selectDeliveryReminderInformation = "SELECT a.orders_deliverydate, a.orders_deliverytime, b.users_fname, b.users_lname, b.users_email FROM orders a INNER JOIN users b ON b.users_id = a.users_id WHERE a.orders_deliverydate =@orders_deliverydate";

    public const string selctDeliveryReminderSentEmailDate = "select DISTINCT TOP 10 a.deliverydate_date, b.location_name from deliverydate a INNER JOIN location b ON b.location_id = a.location_id WHERE a.deliverydate_reminded = 1 ORDER BY a.deliverydate_date DESC";

    public const string updateDeliveryReminder = "UPDATE deliverydate SET deliverydate_reminded = 1 WHERE deliverydate_date=@deliverydate_date";

    public const string selectShoppingListDates = "SELECT a.deliverydate_id,Convert(VarChar,a.deliverydate_date,101) as deliverydate_date, b.location_id, b.location_name FROM deliverydate a INNER JOIN location b ON b.location_id = a.location_id ORDER BY a.deliverydate_date DESC";

    public const string selectShoppingListProducts = "SELECT product_title, orderproduct_quantity, orderproduct_price, product_store, productlink_buyprice, shelf_name, shelf_position, product_size FROM shopping_list_vw WHERE orders_deliverydate = @orders_deliverydate AND location_id =1 ORDER BY shelf_position ,product_title ";

    //public const string selectShoppingListProducts = "SELECT distinct  SUM(orderproduct_quantity) as orderproduct_quantity,product_title,orderproduct_price, product_store, productlink_buyprice, shelf_name, shelf_position, product_size FROM shopping_list_vw WHERE orders_deliverydate = @orders_deliverydate AND location_id =1 GROUP BY product_title, orderproduct_price, product_store, productlink_buyprice, shelf_name, shelf_position, product_size ORDER BY  shelf_position";



    public const string selectSearchReportDsc = "SELECT location_id, search_word, search_results, COUNT(search_word) AS crap FROM search WHERE location_id = 1 GROUP BY search_word, search_results, location_id ORDER BY crap ASC";

    public const string selectSearchReportAsc = "SELECT location_id, search_word, search_results, COUNT(search_word) AS crap FROM search GROUP BY search_word, search_results, location_id ORDER BY crap DESC";

    public const string selectSearchReportDscbydate = "SELECT     (search_word) ,location_id, search_results, COUNT(search_word) AS crap FROM search WHERE location_id = 1 and search_datetime between @strStartDate AND @strToDate GROUP BY search_word, search_results, location_id  ORDER BY crap DESC";

    public const string selectSearchReportAscbydate = "SELECT     (search_word) ,location_id, search_results, COUNT(search_word) AS crap FROM search WHERE location_id = 1 and search_datetime between @strStartDate AND @strToDate GROUP BY search_word, search_results, location_id  ORDER BY crap ASC";


    public const string selectSearchReportbydateASC = "SELECT (search_word) ,location_id, search_results, COUNT(search_word) AS crap FROM search WHERE location_id = 1 and CONVERT(varchar, search_datetime,101)=@strStartDate  GROUP BY search_word, search_results, location_id  ORDER BY crap ASC";


    public const string selectSearchReportAscbydateSort= "SELECT     (search_word) ,location_id, search_results, COUNT(search_word) AS crap FROM search WHERE location_id = 1 and search_datetime between @strStartDate AND @strToDate GROUP BY search_word, search_results, location_id  ORDER BY crap";


    public const string selectSearchReportAscbydateSort1 = "SELECT     (search_word) ,location_id, search_results, COUNT(search_word) AS crap FROM search WHERE location_id = 1 and CONVERT(varchar, search_datetime,101)=@strStartDate  GROUP BY search_word, search_results, location_id  ORDER BY crap";


    public const string selectSearchReportAscbydate1 = "SELECT     (search_word) ,location_id, search_results, COUNT(search_word) AS crap FROM search WHERE location_id = 1 and CONVERT(varchar, search_datetime,101)=@strStartDate  GROUP BY search_word, search_results, location_id  ORDER BY crap ASC";
    
    /********User Side  Coding**********/


    //Master page
    //public const string selectUserAislesdetails = "SELECT * FROM aisle WHERE aisle_show =1 ORDER BY aisle_name ASC";
    public const string selectUserAislesDetails = "SELECT * FROM aisletop WHERE aisletop_show = 1 ORDER BY aisletop_name ASC";
    //public const string selectUserAislesdetails = "SELECT * FROM aisle WHERE aisle_show =1 ORDER BY aisle_name ASC";

    public const string selectHomePageTxt = "SELECT TOP 1 * FROM sale WHERE location_id =1";

    //Registration Page
    public const string selectUserLoginInfo = "Select * from users WHERE users_email =@username and users_password=@password";

    public const string selectUserEmailInfo = "Select * from users WHERE users_email =@users_email";

    public const string selectUserZipCodeInfo = "Select * from zipcode where zipcode_zipcode=@zipCode";

    //forgot passsword

    public const string updateUserPasswordInfo = "update users set users_password=@password  WHERE users_email=@username";


    //Search Result

    public const string selectSearchDetails1 = "SELECT  min(shelf_id) as shelf_id,shelf_name,min(aisle_id) as aisle_id,min(aisletop_id) AS aisletop_id FROM product_details_vw WHERE location_id =@locId AND productlink_hide = 0  AND shelf_name LIKE ('%'+@strKey+'%') GROUP BY shelf_name";

    //public const string selectSearchDetails2 = "SELECT product_id, product_image, product_image2, productlink_hide, productlink_price, product_description, product_title, product_size, productlink_presale, MIN(shelf_id) AS shelf_id, shelf_name, MIN(aisle_id) AS aisle_id, min(aisletop_id) AS aisletop_id, location_id FROM product_details_vw WHERE location_id =@locId AND productlink_hide = 0 AND product_title LIKE ('%'+@strKey+'%')  GROUP BY product_id, product_image, product_image2, productlink_hide, productlink_price, product_description, product_title, product_size, productlink_presale, shelf_name, location_id";
    //public const string selectSearchDetails2 = "SELECT dbo.product_details_vw.product_id, dbo.product_details_vw.product_image, dbo.product_details_vw.product_image2, dbo.product_details_vw.productlink_hide, dbo.product_details_vw.productlink_price, dbo.product_details_vw.product_description, dbo.product_details_vw.product_title, dbo.product_details_vw.product_size, dbo.product_details_vw.productlink_presale, MIN(dbo.product_details_vw.shelf_id) AS shelf_id, dbo.product_details_vw.shelf_name, MIN(dbo.product_details_vw.aisle_id) AS aisle_id, MIN(dbo.product_details_vw.aisletop_id) AS aisletop_id, dbo.product_details_vw.location_id, dbo.aisletop.aisletop_show FROM  dbo.product_details_vw INNER JOIN dbo.aisletop ON dbo.product_details_vw.aisletop_id = dbo.aisletop.aisletop_id WHERE (dbo.product_details_vw.location_id = @locId) AND (dbo.product_details_vw.productlink_hide = 0) AND (dbo.product_details_vw.product_title LIKE '%' + @strKey + '%') AND (dbo.aisletop.aisletop_show = 1) GROUP BY dbo.product_details_vw.product_id, dbo.product_details_vw.product_image, dbo.product_details_vw.product_image2, dbo.product_details_vw.productlink_hide, dbo.product_details_vw.productlink_price, dbo.product_details_vw.product_description, dbo.product_details_vw.product_title, dbo.product_details_vw.product_size, dbo.product_details_vw.productlink_presale, dbo.product_details_vw.shelf_name, dbo.product_details_vw.location_id, dbo.aisletop.aisletop_show";
    public const string selectSearchDetails2 = "SELECT dbo.product_details_vw.product_id, dbo.product_details_vw.product_image, dbo.product_details_vw.product_image2, dbo.product_details_vw.productlink_hide, dbo.product_details_vw.productlink_price, dbo.product_details_vw.product_description, dbo.product_details_vw.product_title, dbo.product_details_vw.product_size, dbo.product_details_vw.productlink_presale, MIN(dbo.product_details_vw.shelf_id) AS shelf_id, dbo.product_details_vw.shelf_name, MIN(dbo.product_details_vw.aisle_id) AS aisle_id, MIN(dbo.product_details_vw.aisletop_id) AS aisletop_id, dbo.product_details_vw.location_id, dbo.aisletop.aisletop_show FROM  dbo.product_details_vw INNER JOIN dbo.aisletop ON dbo.product_details_vw.aisletop_id = dbo.aisletop.aisletop_id WHERE (dbo.product_details_vw.location_id = @locId) AND (dbo.product_details_vw.productlink_hide = 0) AND (dbo.product_details_vw.product_title LIKE '%' + @strKey + '%') GROUP BY dbo.product_details_vw.product_id, dbo.product_details_vw.product_image, dbo.product_details_vw.product_image2, dbo.product_details_vw.productlink_hide, dbo.product_details_vw.productlink_price, dbo.product_details_vw.product_description, dbo.product_details_vw.product_title, dbo.product_details_vw.product_size, dbo.product_details_vw.productlink_presale, dbo.product_details_vw.shelf_name, dbo.product_details_vw.location_id, dbo.aisletop.aisletop_show";

    public const string insertSearchResultInfo = "insert into search(search_word,search_datetime,location_id,search_results,users_id) values(@key,@dtToday,@locationId,@total,@userId)";

    public const string insertSearchResultInfo1 = "insert into search(search_word,search_datetime,location_id,search_results) values(@key,@dtToday,@locationId,@total)";

    /********** shop *************/
    //shelf

    public const string selectUserShelfNameDetails = "SELECT a.shelf_name, a.shelf_id, b.aisle_id, c.aisle_name, a.shelf_show FROM            dbo.shelf AS a INNER JOIN dbo.aislelink AS b ON b.shelf_id = a.shelf_id INNER JOIN  dbo.aisle AS c ON c.aisle_id = b.aisle_id WHERE        (b.aisle_id = @aisleId) AND (a.shelf_show = 0) ORDER BY a.shelf_name";

    public const string selectUserPopShelfNameDetails = "SELECT a.shelf_name, a.shelf_id, b.aisle_id FROM shelf a INNER JOIN aislelink b ON b.shelf_id = a.shelf_id WHERE b.aisle_id =@aisleId AND a.shelf_popular = 1;";

    public const string selectUserAisleNameDetails = "SELECT distinct a.aisletop_name,a.aisletop_id, c.aisle_name, c.aisle_id FROM aisletop a INNER JOIN aisletopaisle b ON b.aisletop_id = a.aisletop_id INNER JOIN aisle c ON c.aisle_id = b.aisle_id WHERE a.aisletop_id =@aisletop_id and c.aisle_show=1 ORDER BY c.aisle_name ASC";

    //public const string selectUserShelfdetails = "SELECT b.shelf_name, b.shelf_id,a.aisle_id FROM aislelink a INNER JOIN shelf b ON b.shelf_id = a.shelf_id WHERE a.aisle_id =@aisle_id ORDER BY b.shelf_name ASC";

    //public const string selectUserShelfdetails = "SELECT b.shelf_name, b.shelf_id, a.aisle_id, dbo.aisletopaisle.aisletop_id FROM dbo.aislelink AS a INNER JOIN dbo.shelf AS b ON b.shelf_id = a.shelf_id INNER JOIN dbo.aisletopaisle ON a.aisle_id = dbo.aisletopaisle.aisle_id WHERE (aisletopaisle.aisletop_id = @aisletop_id  AND a.aisle_id=@aisle_id) ORDER BY b.shelf_name";

    //new p
    public const string selectUserShelfDetails = "SELECT b.shelf_name, b.shelf_id, a.aisle_id, dbo.aisletopaisle.aisletop_id FROM dbo.aislelink AS a INNER JOIN dbo.shelf AS b ON b.shelf_id = a.shelf_id INNER JOIN dbo.aisletopaisle ON a.aisle_id = dbo.aisletopaisle.aisle_id WHERE (aisletopaisle.aisletop_id = @aisletop_id  AND a.aisle_id=@aisle_id AND b.shelf_show<>1) ORDER BY b.shelf_name";

    //public const string selectUserShelfName = "SELECT aisletop_name,aisletop_id FROM aisletop WHERE aisletop_id=@aisletop_id ";

    //public const string selectUserShelfName = "SELECT aisle_name,aisle_id FROM aisle WHERE aisle_id=@aisleId";

    public const string selectUserShelfName = "SELECT aisletop_name,aisletop_id FROM aisletop WHERE aisletop_id=@aisletop_id ";

    //Product
    public const string selectAisleInfo = "SELECT a.shelf_name, c.aisle_name FROM shelf a INNER JOIN aislelink b ON b.shelf_id = a.shelf_id INNER JOIN aisle c ON c.aisle_id=b.aisle_id WHERE a.shelf_id =@intShelf  AND b.aisle_id =@aisleId";

    // public const string selectShopProductInfo = "SELECT distinct product_id, product_image, product_image2, productlink_hide, productlink_price, product_description, product_title, product_size, productlink_presale, location_id,aisle_id,shelf_id FROM product_details_vw WHERE aisletop_id = @aisletop_id and  shelf_id =@intShelf AND location_id =@intLoc AND productlink_hide <> 1 ORDER BY productlink_price ASC";
    //public const string selectMasterListProductInfo = "select * from product_details_vw where product_id in (select  TOP 100 op.product_id  from orderproduct op,orders o where o.orders_id=op.orders_id  and o.users_id=@userid order by op.orderproduct_id desc ) ";

    public const string selectMasterListProductInfo = "select distinct  product_image2,aisle_id,product_description,shelf_id,product_id,productlink_price,productlink_presale,product_size,product_title,product_image from product_details_vw where product_id in (select  TOP 100 op.product_id  from orderproduct op,orders o where o.orders_id=op.orders_id  and o.users_id=@userid order by op.orderproduct_id desc ) and productlink_hide=0     ";

    //new p
    //public const string selectShopProductInfo = "SELECT distinct product_id, product_image, product_image2, productlink_hide, productlink_price, product_description, product_title, product_size, productlink_presale, location_id,aisle_id,shelf_id FROM product_details_vw WHERE shelf_id =@intShelf AND location_id =@intLoc AND productlink_hide <> 1 ORDER BY productlink_price ASC";
    public const string selectShopProductInfo = "SELECT distinct product_id, product_image, product_image2, productlink_hide, productlink_price, product_description, product_title, product_size, productlink_presale, location_id,aisle_id,shelf_id FROM product_details_vw WHERE shelf_id =@intShelf AND location_id =@intLoc AND productlink_hide <> 1 ORDER BY product_title ASC";

    public const string selectShopPopularProductInfo = "SELECT distinct product_id, product_image,product_image2, productlink_featured, productlink_hide, productlink_price, product_description, product_title, product_size, productlink_presale, location_id,aisle_id,shelf_id FROM product_details_vw WHERE productlink_featured = 1 AND aisle_id =@aisleId AND shelf_id =@intShelf AND location_id =@intLoc AND productlink_hide <> 1 ORDER BY product_title ASC";


    //Cart
    public const string selectProductPriceAmount = "select pl.productlink_price,pl.product_id,p.product_image,p.product_size,pl.productlink_tax,pl.productlink_soda,p.product_image2,p.product_description from productlink pl,product p where pl.product_id=p.product_id and p.product_title=@strProdNm and pl.product_id=@prodId";


    public const string selectProductInfoDetails = "select p.product_title,p.product_description,p.product_image,p.product_size,p.product_image2,p.product_comments,p.product_store,pl.location_id,pl.product_id,pl.shelf_id,pl.aisle_id,pl.aislelink_id,pl.productlink_price,pl.productlink_buyprice,pl.productlink_presale,pl.productlink_soda,pl.productlink_suggest,pl.productlink_tax,pl.productlink_featured,pl.productlink_hide,ProductType from  product p,productlink pl where pl.product_id=p.product_id and p.product_id=@productId";

    public const string selectMinOrderAmt = "select u.users_id,z.ZipOrderSize,z.zipcode_zipcode from zipcode z,users u where u.users_zip=z.zipcode_zipcode and u.users_id=@userId";


    public const string selectSuggestProdInfo = "SELECT TOP 7 product_id, product_image, product_title, productlink_price, product_description, productlink_suggest,product_size FROM product_details_vw  WHERE location_id=@locId  AND (productlink_suggest = 1)  GROUP BY product_id, product_image, product_title, productlink_price, product_description, productlink_suggest, product_size ORDER BY product_title";

    public const string selectdDelveryTimeInformation = "SELECT DISTINCT TOP 3 deliverydate_id, deliverydate_date FROM deliverysched_available_vw WHERE location_id =1 ORDER BY deliverydate_date";


    //public const string selectDelveryTimeInfo = "SELECT  deliverytime_id, deliverydatetime_capacity, deliverytime_time FROM deliverysched_available_vw WHERE location_id = 1 AND deliverydate_id =@delId";
    //public const string selectDelveryTimeInfo = "SELECT DISTINCT  deliverytime_id, deliverydatetime_capacity, deliverytime_time, Zone FROM deliverysched_available_vw WHERE (location_id = 1) AND (Zone = @delId)";
    //public const string selectDelveryTimeInfo = "SELECT DISTINCT deliverytime_id, deliverytime_time, Zone FROM deliverysched_available_vw WHERE (location_id = 1) AND (Zone = @delId) AND (deliverydate_id=@deliverydate_id)";

    public const string selectDelveryTimeInfo = "SELECT  deliverytime_id, deliverydatetime_capacity, deliverytime_time FROM deliverysched_available_vw WHERE location_id = 1 AND deliverydate_id =@delId  ORDER BY deliverytime_time";

    //Featured 
    public const string selectFeaturedProductInfo = "SELECT distinct product_id, product_image, productlink_hide, productlink_price, product_description, product_title, product_size, case when productlink_presale is null then '0' else productlink_presale end as productlink_presale, location_id FROM product_details_vw WHERE location_id =@intLoc AND productlink_hide <> 1 AND  productlink_featured = 1 ORDER BY product_title";
    //sales

    public const string selectSalesProductInfo = "SELECT distinct product_id, product_image, productlink_hide, productlink_price, product_description, product_title, product_size, productlink_presale, location_id FROM product_details_vw WHERE location_id =@intLoc AND productlink_hide <> 1 AND productlink_presale IS NOT NULL ORDER BY product_title";
    //user
    public const string selectUserDetailsInfo = "SELECT users.users_id, users.users_fname, users.users_lname, users.users_phone, users.users_email, users.users_cell, users.users_address1, users.users_address2, users.users_city, users.users_state, users.users_zip, users.users_password, users.users_baddress1, users.users_baddress2, users.users_bcity, users.users_bstate, users.users_bzip, users.users_creditcard, users.users_expirationdate, users.location_id, users.users_hear, users.users_estimate, users.users_accountvalue, users.users_regdate, users.users_newsletter, users.usersstatus_id, users.userstype_id, users.users_under100, users.users_over100,  zipcode.zipcode_zipcode FROM users CROSS JOIN zipcode WHERE (users.users_id = @userId)";

    //public const string selectZoneInfo = "select * from zipcode where zipcode_id=@zipcode_id";

    public const string selectZoneInfo = "SELECT zipcode.zipcode_id, zipcode.zipcode_zipcode, zipcode.location_id, zipcode.zipcode_name, zipcode.ZipOrderSize, zipcode.Zone, Zone.zone AS Expr1, Zone.zone_id FROM zipcode CROSS JOIN  Zone WHERE (zipcode.zipcode_id = @zipcode_id)";

    public const string updateUserPhoneDetailsInfo = "update users set users_phone=@phoneNm1,users_cell=@phoneNm2 where users_id=@userId";

    public const string selectUserEmailalreadyExit = "select * from users where users_email=@email and users_id!=@userId";

    public const string updateUserLoginDetailsInfo = "update users set users_email=@email,users_password=@pwd where users_id=@userId";

    public const string updateUserDeliveryAddressDetails = "update users set users_address1=@strAddress1,users_address2=@strAddress2,users_city=@city,users_state=@state,users_zip=@zipcode where users_id=@userId";

    public const string updateUserBillingAddressDetails = "update users set users_baddress1=@strAddress1,users_baddress2=@strAddress2,users_bcity=@city,users_bstate=@state,users_bzip=@zipcode where users_id=@userId";

    //Registration

    public const string insertNonDeliveryZoneInfo = "insert into future(future_email,future_zip,future_name,future_date) values(@email,@zipCode,@name,@date1)";

    //public const string insertNewUserInformation = "insert into users(users_fname,users_lname,users_phone,users_cell,users_email,users_address1,users_address2,users_city,users_state,users_zip,users_password,location_id,users_hear,users_estimate,users_regdate,users_accountvalue,users_newsletter,usersstatus_id,users_under100,users_over100) values(@fName,@lName,@phone,@cell,@email,@address1,@address2,@city,@state,@zip,@pwd,@locId,@strHear,@estimate,@date1,@accValue,@newsletter,@statusId,@under100,@over100)";

    public const string insertNewUserInformation = "insert into users(users_fname,users_lname,users_phone,users_cell,users_email,users_address1,users_address2,users_city,users_state,users_zip,users_password,location_id,users_hear,users_estimate,users_regdate,users_accountvalue,users_newsletter,usersstatus_id,users_under100,users_over100) values(@fName,@lName,@phone,@cell,@email,@address1,@address2,@city,@state,@zip,@pwd,@locId,@strHear,@estimate,@date1,@accValue,@newsletter,@statusId,@under100,@over100);select @@identity";


    //deleivery zip 

    public const string selectZipCodeAndOrdAmtInfo = "select * from zipcode";


    //Account Fund 

    public const string insertAccFundParentInfo = "insert into parent(parent_fname,parent_lname,parent_email,users_id) values(@fname,@lname,@email,@userId)";

    public const string selectUserParentEmailInfo = "select * from parent where parent_email=@email";

    public const string selectPaymentOptionInfo = "select * from paymnet_options_mapping";

    public const string selectParentDetailsInfo = "select * from parent where parent_id=@parentId";

    public const string insertAccFundTransactionInformation = "insert into transactions(transactions_date,transactions_amount,users_id,parent_id,transactions_fname,transactions_lname,transactions_address,transactions_address2,transactions_city,transactions_state,transactions_zip,transactions_phone,GetWayTransactionId) values(@dateToday,@amt,@intUserId,@parentId,@fname,@lname,@address1,@address2,@city,@state,@zip,@phone,@transactionId)";


    public const string updateUserAccInfo = "update users set users_accountvalue=@userAccAmt where users_id=@userId";

    //My Accout Page

    public const string selectUserTransactionInfo = "SELECT transactions_id,transactions_amount,Convert(VarChar,transactions_date,101) as Date1,orders_id,transactions_comment,parent_id,transactions_fname FROM transactions WHERE users_id =@intUserId  ORDER BY transactions_date DESC";

    public const string selectUserOrderDetailsInfo = "SELECT TOP 3 orders_id,orders_totalfinal,Convert(VarChar,orders_datetime,101) as orderDate1,orders_number FROM orders WHERE users_id =@intUserId ORDER BY orders_datetime DESC";

    public const string selectUserOrderInformation = "SELECT users_id,orders_id,orders_totalfinal,Convert(VarChar,orders_datetime,101) as ordDate,Convert(VarChar,orders_deliverydate,101) as delDate,orders_number FROM orders WHERE users_id =@intUserId ORDER BY orders_datetime DESC";


    //public const string selectUserOrderInfo = "select orders_id,orders_address,orders_address2,orders_city,orders_state,orders_zip,orders_number,(convert(varchar,orders_deliverydate,101)+' at '+orders_deliverytime) as delivery ,orders_totalfinal,(convert(varchar,orders_datetime,101)+' '+CONVERT(CHAR(8),orders_datetime,8)) as ordered,orders_paymenttype,orders_complimentary,orders_instructions,orders_grocerytotal,orders_tax,orders_sodadeposit,orders_deliveryfee,orders_tip,orders_GroceriesTax  from orders WHERE users_id =@userId and orders_id=@orderId";
    public const string selectUserOrderInfo = "select orders_id,orders_address,orders_address2,orders_city,orders_state,orders_zip,orders_number,(convert(varchar,orders_deliverydate,101)+' at '+orders_deliverytime) as delivery ,orders_totalfinal,(convert(varchar,orders_datetime,101)+' '+CONVERT(CHAR(8),orders_datetime,8)) as ordered,orders_paymenttype,orders_complimentary,orders_instructions,orders_grocerytotal,orders_tax,orders_tax2,orders_tax3,orders_sodadeposit,orders_deliveryfee,orders_tip,orders_accountname,orders_accountnumber  from orders WHERE users_id =@userId and orders_id=@orderId";


    public const string selectUserOrderProductDetail = "SELECT a.orders_deliverydate, a.orders_id, b.orderproduct_quantity, b.orderproduct_price, c.product_id, MIN(c.product_title) AS product_title, c.product_image, d.productlink_hide,c.product_size FROM dbo.orders a INNER JOIN dbo.orderproduct b ON b.orders_id = a.orders_id INNER JOIN dbo.product c ON c.product_id = b.product_id INNER JOIN  dbo.productlink d ON d.product_id = c.product_id WHERE     (a.users_id =@userId) AND (a.orders_id =@orderId) AND (d.productlink_hide <> 1) GROUP BY a.orders_deliverydate, a.orders_id, b.orderproduct_quantity, b.orderproduct_price, c.product_id, c.product_title, c.product_image, d.productlink_hide, d.shelf_id,c.product_size ORDER BY product_title";


    //Shop

    public const string selectDeliveryDateInformation = "SELECT TOP 2 deliverydate_date FROM deliverydates_available_vw WHERE location_id =@locId";

    // public const string selectUserDeliveryDateInformation = "SELECT   TOP (2) d.deliverydate_id,d.deliverydate_date FROM deliverydate d,deliverydatezip z where d.location_id=@locId and d.deliverydate_date > DATEADD(hh, 24, GETDATE()) and d.deliverydate_id=z.deliverydate_id and zipcode_id=@intZip";

   // public const string selectUserDeliveryDateInformation = "SELECT   TOP (2) d.deliverydate_id,d.deliverydate_date FROM deliverydate d,deliverydatezip z,zipcode ZC where d.location_id=1 and d.deliverydate_date > DATEADD(hh, 0, GETDATE()) and d.deliverydate_id=z.deliverydate_id and ZC.zipcode_id=z.zipcode_id and ZC.zipcode_zipcode=@intZip order by d.deliverydate_date";

    public const string selectUserDeliveryDateInformation = "SELECT   TOP (2) d.deliverydate_id,d.deliverydate_date FROM deliverydate d,deliverydatezip z,zipcode ZC where d.location_id=1 and  DATEADD(hh, 21,d.deliverydate_date) > DATEADD(hh, 24, GETDATE()) and d.deliverydate_id=z.deliverydate_id and ZC.zipcode_id=z.zipcode_id and ZC.zipcode_zipcode=@intZip order by d.deliverydate_date";
   
    public const string selectdUserShopDelveryTimeInformation = "SELECT DISTINCT TOP 2 deliverydate_id, deliverydate_date FROM deliverysched_available_vw WHERE location_id =1 ORDER BY deliverydate_date";

    public const string selectdUserNewDelveryTimeInformation = "SELECT DISTINCT  deliverydate_id, deliverydate_date FROM deliverysched_available_vw WHERE location_id =1 ORDER BY deliverydate_date";


    //Coupon

    public const string selectCouponInformation = "SELECT coupon_hide FROM coupon WHERE coupon_hide <> 0 and coupon_code =@strCoupon";

    public const string selectUserCouponInfo = "SELECT a.users_id, a.coupon_id, b.coupon_code, b.coupon_amount FROM couponlink a INNER JOIN coupon b ON b.coupon_id = a.coupon_id WHERE b.coupon_code =@strCoupon  AND a.users_id =@intUserId";

    public const string selectCouponDetailInfo = "SELECT b.coupon_id, b.coupon_code, b.coupon_amount FROM coupon b WHERE b.coupon_code = @strCoupon";

    public const string insertUserCouponTransaction = "insert into transactions(transactions_date,transactions_amount,users_id,transactions_comment,transactions_fname,coupon_id) values(@dtToday,@amt,@intUserId,@strComment,@fName,@couponId); select @@identity";

    public const string insertUserCouponLink = "insert into couponlink(users_id,coupon_id)values(@intUserId,@couponId)";

    //Saved list

    public const string checkListNameAlreadyExist = "select * from list where list_name=@strList and users_id=@users_id";

    public const string checkListNameAlreadyExistadmin = "select * from list where list_name=@strList and list_type=@type";

    public const string insertSavedListInfo = "insert into list(list_name,users_id,location_id,list_type)values(@strListNm,@userId,@intLocId,@listType);select @@identity";

    public const string insertSavedListInfoadmin = "insert into list(list_name,location_id,list_type)values(@strListNm,@intLocId,@listType);select @@identity";

    public const string insertSavedListMappingInfo = "insert into listlink(list_id,product_id,listlink_qty)values(@listId,@intProdId,@prodQty)";

    public const string selectUserSavedListInformation = "select list_id,list_name,users_id,list_type,location_id from list where users_id=@intUserId";

    public const string deleteUserSavedList = "delete from list where list_id=@listId and users_id=@intUserId";

    public const string deleteUserSavedListMappingInfo = "delete from listlink where list_id=@listId";

    public const string selectUserSavedListDetails = "select a.list_id,a.list_name,a.users_id,b.product_id,b.listlink_qty,p.productlink_price from list a,listlink b,productlink p where a.list_id=b.list_id and p.product_id=b.product_id and a.list_id=@intListId and a.users_id=@intUserId  and p.productlink_hide=0";

    public const string selectUserSavedListDetailspremade = "select a.list_id,a.list_name,a.users_id,b.product_id,b.listlink_qty,p.productlink_price,a.list_type from list a,listlink b,productlink p where a.list_id=b.list_id and p.product_id=b.product_id and a.list_id=@intListId and a.list_type=@type";

    public const string selectListProductDetails = "select p.product_title,pl.productlink_price,pl.product_id,p.product_image,p.product_size,pl.productlink_tax,pl.productlink_soda,p.product_image2,p.product_description from productlink pl,product p where pl.product_id=p.product_id and p.product_id=@intProdId";


    //public const string selectUserPickTimeDelDateInfo = "SELECT   TOP (3) d.deliverydate_id,d.deliverydate_date,ZC.zone FROM deliverydate d,deliverydatezip z,Zone ZC where d.location_id=1 and d.deliverydate_date > DATEADD(hh, 24, GETDATE()) and d.deliverydate_id=z.deliverydate_id and ZC.zipcode_id=z.zipcode_id and ZC.zone=@intZip order by d.deliverydate_date desc";

    //public const string selectUserPickTimeDelDateInfo = "SELECT   TOP (3) d.deliverydate_id,d.deliverydate_date,ZC.Zone FROM deliverydate d,deliverydatezip z,Zone ZC,Zone z1 where d.location_id=1 and ZC.Zone=@intZip and d.deliverydate_date > DATEADD(hh, 24, GETDATE()) and d.deliverydate_id=z.deliverydate_id and ZC.zone_id=z.zone_id  and ZC.Zone=z1.Zone group by d.deliverydate_date,d.deliverydate_id,ZC.zone order by d.deliverydate_date desc";
    //public const string selectUserPickTimeDelDateInfo = "SELECT TOP (6) d.deliverydate_id, d.deliverydate_date, ZC.zone, z.zone_id FROM deliverydate AS d INNER JOIN deliverydatezip AS z ON d.deliverydate_id = z.deliverydate_id INNER JOIN Zone AS ZC ON z.zone_id = ZC.zone_id INNER JOIN Zone AS z1 ON ZC.zone = z1.zone AND z.zone_id = z1.zone_id WHERE (d.location_id = 1) AND (d.deliverydate_date > DATEADD(hh, 1, GETDATE())) AND (z.zone_id = @intZip) GROUP BY d.deliverydate_date, d.deliverydate_id, ZC.zone, z.zone_id ORDER BY d.deliverydate_date DESC";
    //public const string selectUserPickTimeDelDateInfo = "SELECT   TOP (3) d.deliverydate_id,d.deliverydate_date FROM deliverydate d,deliverydatezip z,zipcode ZC where d.location_id=1 and d.deliverydate_date > DATEADD(hh, 2, GETDATE()) and d.deliverydate_id=z.deliverydate_id and ZC.zipcode_id=z.zipcode_id and ZC.zipcode_zipcode=@intZip order by d.deliverydate_date desc";
   // public const string selectUserPickTimeDelDateInfo = "SELECT d.deliverydate_id,d.deliverydate_date FROM deliverydate d,deliverydatezip z,zipcode ZC where d.location_id=1 and d.deliverydate_date > DATEADD(hh, 1, GETDATE()) and d.deliverydate_id=z.deliverydate_id and ZC.zipcode_id=z.zipcode_id and ZC.zipcode_zipcode=@intZip order by d.deliverydate_date asc";
    ///public const string selectUserPickTimeDelDateInfo = "SELECT  d.deliverydate_id,d.deliverydate_date FROM deliverydate d,deliverydatezip z,zipcode ZC where d.location_id=1 and DATEADD(hh, 20,d.deliverydate_date) > DATEADD(hh, 24, GETDATE()) and d.deliverydate_id=z.deliverydate_id and ZC.zipcode_id=z.zipcode_id and ZC.zipcode_zipcode=@intZip order by d.deliverydate_date";
    ///
    public const string selectUserPickTimeDelDateInfo = "select distinct d.deliverydate_id,d.deliverydate_date from deliverytime t inner join deliverydatetime ddt on t.deliverytime_id=ddt.deliverytime_id inner join deliverydate d on  d.deliverydate_id=ddt.deliverydate_id inner join deliverydatezip z on d.deliverydate_id=z.deliverydate_id inner join zipcode ZC on ZC.zipcode_id=z.zipcode_id where DATEADD(hh, t.deliverytime_cuttime,d.deliverydate_date) > DATEADD(hh, 24, GETDATE()) and ZC.zipcode_zipcode=@intZip order by d.deliverydate_date";
    
    //Payment Page
    public const string selectAllOrderInfo = "select top 1 orders_number from orders order by orders_id desc";


    public const string selectAllTransInfo = "select top 1 transactions_id from transactions order by transactions_id desc";

    public const string insertOrderInformation = "INSERT INTO orders(users_id,orders_address,orders_address2,orders_city,orders_state,orders_zip,orders_datetime,orders_grocerytotal,orders_instructions,orders_number,orders_complimentary,orders_paymenttype,orders_totalfinal,orders_sodadeposit,orders_deliverydate,orders_deliverytime,orders_deliveryfee,orders_tip,orders_tax,orders_tax2,orders_tax3)  values(@userId,@add1,@add2,@city,@state,@zip,@dtToday,@groceryTot,@special,@ordNum,@complimentry,@payType,@totalFinal,@soda,@DelDate,@DelTime,@delFee,@tip,@taxfood,@taxnonfood,@tax); select @@identity";


    public const string insertOrderProductInfo = "insert into orderproduct(orders_id,product_id,orderproduct_quantity,orderproduct_price) values(@orderId,@intProdId,@qty,@price)";

    public const string updateUserLoyalityInfo = "update users set users_over100=@intOver100 where users_id=@userId";

    public const string updateUserLoyalityInfo1 = "update users set users_under100=@intUnder100 where users_id=@userId";

    public const string selectDeliveryInfo = "SELECT top 1 a.deliverydatetime_id, a.deliverydatetime_capacity FROM deliverydatetime a INNER JOIN  deliverydate b ON b.deliverydate_id = a.deliverydate_id  INNER JOIN deliverytime c ON c.deliverytime_id = a.deliverytime_id  WHERE deliverydate_date=@strDelDate AND  c.deliverytime_id=@intTime";

    public const string updateDeliveryInfo = "UPDATE deliverydatetime SET deliverydatetime_capacity =@intCapVal  WHERE deliverydatetime_id =@intId";

    public const string selectDelveryTime = "select * from deliverytime where deliverytime_id=@intTime";

    public const string InsertTransactionInfo = "insert into transactions(transactions_date,transactions_amount,transactions_comment,users_id,orders_id,GetWayTransactionId) values(@dtToday,@amt,@comment,@intUserId,@orderId,@tranId)";

    public const string updateUserBillingInfo = "update users set users_baddress1=@add1,users_baddress2=@add2,users_bcity=@city,users_bstate=@state,users_bzip=@zip where users_id=@userId";


    public const string insertRegisterTransInfo = "insert into transactions(transactions_date,transactions_amount,transactions_fname,transactions_comment,users_id) values(@dtToday,@amt,@FName,@comment,@intUserId)";
    public const string selectUserEmailAddress = "select users_fname from users where users_id=@users_id";




    //New added(Admin reports)

    public const string selectUserReportInfo = "select users_id,(users_fname+' '+users_lname)as userName,users_email,users_address1,users_city,users_state,users_zip,users_phone,convert(varchar, users_regdate,101) as date1 from users  order by convert(varchar, users_regdate,101) desc";


    public const string selectUserReportClientZipInfo = "select users_id,(users_fname+' '+users_lname)as userName,users_email,users_address1,users_city,users_state,users_zip,users_phone,convert(varchar, users_regdate,101) as date1 from users where users_zip=@ZipCode order by convert(varchar, users_regdate,101) desc";

    public const string selectStateInfo = "select state_long_name from State where state_short_name=@stateId";


    public const string selectGetClientActivityInfo = "select users_id,(users_fname+' '+users_lname)as userName,users_email,users_address1,users_city,users_state,users_zip,users_phone,convert(varchar, users_regdate,101) as date1 from users where convert(varchar,users_regdate,101) between @startDate AND @endDate and users_zip=@ZipCode order by users_id desc";


    public const string selectGetInActivityClientInfo = "select  convert(varchar,o.orders_datetime,101) as ordDate,u.users_id,(u.users_fname+' '+u.users_lname)as userName,u.users_email,u.users_address1,u.users_city,u.users_state,u.users_zip,u.users_phone,convert(varchar, u.users_regdate,101) as date1 from users u,orders o where (o.orders_datetime <= DATEADD(d, - @strOrdType, GETDATE())) and o.users_id=u.users_id order by o.orders_datetime desc";



    //New Querry added for product info

    public const string selectListadmintDetails = "select * from listlink where list_id=@listId";

    public const string selectProductdetails = "select p.product_title,pl.productlink_price,pl.product_id,p.product_image,p.product_size,pl.productlink_tax,pl.productlink_soda,p.product_image2,p.product_description,pl.producttype_minorder from productlink pl,product p where pl.product_id=p.product_id and pl.product_id=@prodId";

    public const string insertAddressInfo = "insert into UserAddressInfo(address,address2,City,State,Zip,instruction,User_Id) values(@address,@address2,@city,@state,@zip,@instruction,@User_Id)";

    public const string deleteAddressInfo = "delete from UserAddressInfo where User_Id=@User_Id";

    public const string selectAddressInfo = "select address,address2,City,State,Zip,instruction from UserAddressInfo where User_Id=@User_Id";

    // Loyalty Program

    public const string insertOrderCountTransInfo = "insert into OrderCount(UserId,OrderCount,OrderMonth) values(@UserId,@OrderCount,@OrderMonth)";
    public const string selectOrderCountInfo = "select OrderCount,OrderMonth from OrderCount where UserId=@userId";
    public const string updateOrderCountInfo = "update OrderCount set OrderCount=@OrderCount,OrderMonth=@OrderMonth where UserId=@UserId";
    public const string selectUserDetailsInfoForLoyoloty = "SELECT * from USERS where users_id=@users_id";
    public const string selectUserDetailsInfoGetZip = "SELECT dbo.zipcode.zipcode_zipcode, dbo.UserAddressInfo.Zip FROM dbo.zipcode INNER JOIN  dbo.UserAddressInfo ON dbo.zipcode.zipcode_zipcode = dbo.UserAddressInfo.Zip WHERE        (dbo.UserAddressInfo.User_Id = @User_Id)";

    public const string updateorderDetailInfo1 = "update orders set orders_address=@address1,orders_address2=@address2,orders_city=@city,orders_zip=@zip,orders_state=@state where orders_id=@orderid and users_id=@userid";

    public const string getuserorder_count = "SELECT convert(varchar(5),MAX(orders_number)) + '-' + convert(varchar(5),count(orders_id)) AS invoice_number FROM orders WHERE users_id =@users_id";
    public const string getuserorder_count1 = "SELECT convert(varchar(5),count(orders_id)) AS invoice_number FROM orders WHERE users_id =@users_id";

    public const string updateProductallPriceInfo = "update productlink set productlink_price=@price,productlink_presale=@saleprice,productlink_buyprice=@buyprice where product_id=@intProductID";
    public const string updateProductallPriceInfo1 = "update productlink set productlink_price=@price,productlink_buyprice=@buyprice where product_id=@intProductID";

    public const string selectUserExmailAddress_zip = "SELECT users_fname, users_email, location_id from users WHERE usersstatus_id =@usersstatus_id AND users_newsletter =@users_newsletter AND users_zip=@users_zip";

    public const string deleteShoppinglistnew1 = "DELETE FROM listlink WHERE product_id=@intProductID AND list_id=@listID";


    //Upload prodcut price

    public const string productListDetailsUPC1 = "SELECT a.product_upc, a.product_id, a.product_title, a.product_size As Size,a.product_description As description ,a.product_image, b.productlink_id, b.productlink_hide, b.productlink_buyprice, b.productlink_presale, b.productlink_buyprice, b.productlink_price, b.location_id, d.shelf_name, d.shelf_id, e.location_name FROM product a INNER JOIN productlink b ON b.product_id = a.product_id INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND d.shelf_id =@shefId AND a.product_upc LIKE ('%'+@strUPC+'%') ORDER BY a.product_upc";

    public const string productListDetailsUPC2 = "SELECT a.product_upc, a.product_id, a.product_title, a.product_size As Size,a.product_description As description ,a.product_image, b.productlink_id, b.productlink_hide, b.productlink_buyprice, b.productlink_presale, b.productlink_buyprice, b.productlink_price, b.location_id, d.shelf_name, d.shelf_id, e.location_name FROM product a INNER JOIN productlink b ON b.product_id = a.product_id INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND a.product_upc LIKE ('%'+@strUPC+'%')  ORDER BY a.product_upc";

    public const string productListDetailsUPC5 = "SELECT a.product_upc, a.product_id, a.product_title, a.product_size As Size,a.product_description As description ,a.product_image, b.productlink_id, b.productlink_hide, b.productlink_buyprice, b.productlink_presale, b.productlink_buyprice, b.productlink_price, b.location_id, d.shelf_name, d.shelf_id, e.location_name FROM product a INNER JOIN productlink b ON b.product_id = a.product_id INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND (a.product_title LIKE ('%'+@strKey+'%') OR a.product_description LIKE ('%'+@strKey+'%')) AND a.product_upc LIKE ('%'+@strUPC+'%')  ORDER BY a.product_upc";

    public const string productListDetailsUPC7 = "SELECT a.product_upc, a.product_id, a.product_title, a.product_size As Size,a.product_description As description ,a.product_image, b.productlink_id, b.productlink_hide, b.productlink_buyprice, b.productlink_presale, b.productlink_buyprice, b.productlink_price, b.location_id, d.shelf_name, d.shelf_id, e.location_name FROM product a INNER JOIN productlink b ON b.product_id = a.product_id  INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND (a.product_title LIKE ('%'+@strKey+'%') OR a.product_description LIKE ('%'+@strKey+'%')) ORDER BY a.product_title";

    public const string productListDetails4 = "SELECT a.product_id,a.product_title As Title,b.productlink_saletitle As SalesTitle,a.product_size As Size,a.product_description As description,a.product_upc As UPC,a.product_image As Image1,a.product_image2 As Image2,b.productlink_id, b.productlink_buyprice, b.productlink_presale as Persale,b.productlink_price as Price,b.productlink_suggest As Suggest,b.productlink_featured As Featured FROM product a INNER JOIN productlink b ON b.product_id = a.product_id INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId ORDER BY a.product_title";

    public const string productListDetails5 = "SELECT a.product_id,a.product_title As Title,b.productlink_saletitle As SalesTitle,a.product_size As Size,a.product_description As description,a.product_upc As UPC,a.product_image As Image1,a.product_image2 As Image2,b.productlink_id, b.productlink_buyprice, b.productlink_presale as Persale,b.productlink_price as Price,b.productlink_suggest As Suggest,b.productlink_featured As Featured FROM product a INNER JOIN productlink b ON b.product_id = a.product_id  INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND d.shelf_id =@shefId ORDER BY a.product_title";

    public const string productListDetails6 = "SELECT a.product_id,a.product_title As Title,b.productlink_saletitle As SalesTitle,a.product_size As Size,a.product_description As description,a.product_upc As UPC,a.product_image As Image1,a.product_image2 As Image2,b.productlink_id, b.productlink_buyprice, b.productlink_presale as Persale,b.productlink_price as Price,b.productlink_suggest As Suggest,b.productlink_featured As Featured FROM product a INNER JOIN productlink b ON b.product_id = a.product_id  INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND d.shelf_id =@shefId AND (a.product_title LIKE ('%'+@strKey+'%') OR a.product_description LIKE ('%'+@strKey+'%')) ORDER BY a.product_title";

    public const string productListDetails7 = "SELECT a.product_id,a.product_title As Title,b.productlink_saletitle As SalesTitle,a.product_size As Size,a.product_description As description,a.product_upc As UPC,a.product_image As Image1,a.product_image2 As Image2,b.productlink_id, b.productlink_buyprice, b.productlink_presale as Persale,b.productlink_price as Price,b.productlink_suggest As Suggest,b.productlink_featured As Featured FROM product a INNER JOIN productlink b ON b.product_id = a.product_id INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND d.shelf_id =@shefId AND (a.product_title LIKE ('%'+@strKey+'%')  OR a.product_description LIKE ('%'+@strKey+'%')) AND a.product_upc LIKE ('%'+@strUPC+'%')  ORDER BY a.product_upc";

    public const string productListDetailsUPC3 = "SELECT a.product_id,a.product_title As Title,b.productlink_saletitle As SalesTitle,a.product_size As Size,a.product_description As description,a.product_upc As UPC,a.product_image As Image1,a.product_image2 As Image2,b.productlink_id, b.productlink_buyprice, b.productlink_presale as Persale,b.productlink_price as Price,b.productlink_suggest As Suggest,b.productlink_featured As Featured FROM product a INNER JOIN productlink b ON b.product_id = a.product_id  INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND d.shelf_id =@shefId AND a.product_upc LIKE ('%'+@strUPC+'%') ORDER BY a.product_upc";

    public const string productListDetailsUPC4 = "SELECT a.product_id,a.product_title As Title,b.productlink_saletitle As SalesTitle,a.product_size As Size,a.product_description As description,a.product_upc As UPC,a.product_image As Image1,a.product_image2 As Image2,b.productlink_id, b.productlink_buyprice, b.productlink_presale as Persale,b.productlink_price as Price,b.productlink_suggest As Suggest,b.productlink_featured As Featured FROM product a INNER JOIN productlink b ON b.product_id = a.product_id INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND a.product_upc LIKE ('%'+@strUPC+'%')  ORDER BY a.product_upc";

    public const string productListDetailsUPC6 = "SELECT a.product_id,a.product_title As Title,b.productlink_saletitle As SalesTitle,a.product_size As Size,a.product_description As description,a.product_upc As UPC,a.product_image As Image1,a.product_image2 As Image2,b.productlink_id, b.productlink_buyprice, b.productlink_presale as Persale,b.productlink_price as Price,b.productlink_suggest As Suggest,b.productlink_featured As Featured FROM product a INNER JOIN productlink b ON b.product_id = a.product_id  INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND (a.product_title LIKE ('%'+@strKey+'%') OR a.product_description LIKE ('%'+@strKey+'%')) AND a.product_upc LIKE ('%'+@strUPC+'%')  ORDER BY a.product_upc";

    public const string productListDetailsUPC8 = "SELECT a.product_id, a.product_title, a.product_size As Size,a.product_description As description ,a.product_image As Image1,a.product_image2 As Image2, b.productlink_id, b.productlink_hide, b.productlink_buyprice, b.productlink_presale, b.productlink_buyprice, b.productlink_price, b.location_id, d.shelf_name, d.shelf_id, e.location_name,f.aisle_id,f.aisle_name FROM product a INNER JOIN productlink b ON b.product_id = a.product_id  INNER JOIN shelf d ON d.shelf_id = b.shelf_id INNER JOIN location e on e.location_id = b.location_id WHERE b.location_id =@locationId AND (a.product_title LIKE ('%'+@strKey+'%') OR a.product_description LIKE ('%'+@strKey+'%')) ORDER BY a.product_title";

    public const string updateProductPrice_ifnull = "update productlink set productlink_price=@price,productlink_presale=null,productlink_featured=@recomm,productlink_suggest=@suggest,productlink_saletitle=@saletitle where product_id=@productid";

    public const string updateProductPrice = "update productlink set productlink_price=@price,productlink_presale=@perSale,productlink_featured=@recomm,productlink_suggest=@suggest,productlink_saletitle=@saletitle where product_id=@productid";

    public const string updateProductSize = "update product set product_size=@size,product_description=@desc,product_title=@title,product_image=@image1,product_image2=@image2 where product_id=@productid";

    public const string selectPrductShelfDropdownNew = "select p.product_id,p.product_title from product p,productlink pl where p.product_id=pl.product_id and pl.shelf_id=@strshelfid and pl.productlink_hide='0' order by p.product_title asc";

    public const string salesItemListDetails1 = "SELECT a.product_id, a.product_title, b.productlink_price, b.productlink_id, a.product_size, b.productlink_presale, a.product_image, b.location_id from product a INNER JOIN productlink b ON b.product_id = a.product_id WHERE productlink_presale IS NOT NULL AND b.location_id =@locationId order by a.product_title asc";

    public const string selectDeliveryDateZipDetails = "SELECT b.zipcode_id ,z.zipcode_zipcode FROM deliverydatezip b  INNER JOIN zipcode z ON z.zipcode_id =b.zipcode_id  WHERE b.deliverydate_id =@deliveryId   GROUP BY b.zipcode_id ,z.zipcode_zipcode ";


    public const string selectDeliveryDateZipCapacityDetails = "SELECT a.deliverytime_id, a.deliverydatetime_capacity,b.deliverytime_cuttime, b.deliverytime_time ,a.zipcode_id FROM deliverydatetime a INNER JOIN deliverytime b ON b.deliverytime_id = a.deliverytime_id WHERE a.deliverydate_id =@deliveryId  and  a.zipcode_id=@zip ORDER BY a.deliverytime_id ,b.deliverytime_time";


    public const string selectDeliveryInfo_Details = "SELECT top 1 a.deliverydatetime_id, a.deliverydatetime_capacity FROM deliverydatetime a INNER JOIN  deliverydate b ON b.deliverydate_id = a.deliverydate_id  INNER JOIN deliverytime c ON c.deliverytime_id = a.deliverytime_id  WHERE b.deliverydate_ID=@DeldateID AND deliverydate_date=@strDelDate AND  c.deliverytime_id=@intTime";

}