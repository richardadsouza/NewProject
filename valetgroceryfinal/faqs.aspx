<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="faqs.aspx.cs" Inherits="groceryguys.faqs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: normal;
            color: #000000;
            text-align: justify;
            padding-right: 20px;
            height: 55px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <script type="text/javascript">
        var Image1 = document.getElementById("Image9");
        var Image2 = document.getElementById("Image10");
        var Image3 = document.getElementById("Image11");
        var Image4 = document.getElementById("Image12");
        var Image5 = document.getElementById("Image13");
        var Image6 = document.getElementById("Image14");
    
    //alert(img1);
        Image1.src = "images/subtab1.png";
        Image2.src = "images/subtab2.png";
    Image3.src = "images/subtab3.png";
    Image4.src = "images/subtab4-h.png";
    Image5.src = "images/subtab5.png";
    Image6.src = "images/subtab6.png";   
    </script> 
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table cellpadding="5" cellspacing="0" border="0">
                <tr>
                    <td class="formHeading">
                        Frequently Asked Questions
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr valign="top">
                                <td width="200" align="left">
                                    <ul>
                                        <li><a href="#general" class="Userlink1">General</a></li>
                                        <li><a href="#delivery" class="Userlink1">Delivery</a></li>
                                        <li><a href="#customerservice" class="Userlink1">Customer Service</a></li>
                                    </ul>
                                </td>
                                <td width="200" align="left">
                                    <ul>
                                        <li><a href="#ordering" class="Userlink1">Ordering</a></li>
                                        <li><a href="#membership" class="Userlink1">Membership</a></li>                                       
                                        <li><a href="#security" class="Userlink1">Security & privacy</a></li>
                                    </ul>
                                </td>                               
                            </tr>
                        </table>
                    </td>
                </tr>
               <tr>
                    <td align="left" class="formHeadingNew">
                        <a name="general"></a>General
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: What days and times do you deliver?  </strong>
                        <br />
                        <strong>A:</strong> Currently, we deliver 5 days a week. Our current delivery days are as follows: <br />
                        <ul>
                        <li>Monday 2pm to 7pm </li>
                        <li>Tuesday 2pm to 7pm </li>
                        <li>Wednesday 2pm to 7pm </li>
                        <li>Thursday 2pm to 7pm</li>
                        <li>Friday 2pm to 7pm</li>
                        </ul>
                         <br />
                        We will be adding additional days and times in the near future. If you have suggestions as to days and times that you feel would be more convenient please contact us. Please note that you must place your order by 8pm the evening before your delivery day, Shopping can be done and orders placed on Saturday and Sunday but groceries won't be delivered until the next delivery day.                      
                    </td>
                </tr>
               <tr>
                    <td class="formTextUser">
                        <strong>Q: How can I contact you? </strong>
                        <br />
                        <strong>A:</strong> The easiest way to contact us is by filling out our <a href="ContactUsPage.aspx" class="Userlink1">Contact Form</a> We receive this form immediately and will respond as quickly as possible. Visit our contact us page for other methods of contacting us. 
                        
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q:  I would like my parents/guardians to deposit Shopping Funds for me to withdraw from, how can I do this?   </strong>
                        <br />
                        <strong>A:</strong> It's simple! Contact your parents or guardians and have them click the Shopping Funds link on www.valetgrocery.com. This will walk them through depositing Shopping Funds into your account. Contact us if you need additional help. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: How does your Loyalty Program work? </strong>
                        <br />
                        <strong>A:</strong> We really appreciate customers making Valet Grocery their primary grocery source. To show our appreciation, we give free groceries to customer that place repeat orders. For every 5 orders between $50 and $100, you will receive $5 in free grocery funds. For every 5 orders over $100, you will receive $10 in free grocery funds. Your orders are tracked automatically for you and can be viewed anytime in the "My Account" section of our website. Once you complete either level of our loyalty program, we will deposit the respective amount into your grocery fund account. 
                    </td>
                </tr>
               <tr>
                    <td align="left" class="formHeadingNew">
                        <a name="delivery"></a>Delivery
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: What is your delivery range? </strong>
                        <br />
                        <strong>A:</strong> Our goal is to provide our grocery delivery service to the entire Metro Baton Rouge area which will include Livingston, Ascension and West Baton Rouge Parishes. To ensure excellent service we will start with a couple of designated zip codes and continue to expand our delivery area until all of Metro Baton Rouge is covered. If you don’t see your zipcode or are unsure if we will deliver to your location, simply fill out our online <a href="ContactUsPage.aspx" class="Userlink1">Contact Us</a> form and we will communicate with you as soon as we begin delivering in your area. (For safety reasons we reserve the right to not deliver in high crime areas and / or may limit delivery to specific times of the day) 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: Can I order the same day I want it delivered?    </strong>
                        <br />
                        <strong>A:</strong> Unfortunately we are unable to offer same day delivery at this time. Your order must be made by 8pm the day before your chosen delivery date. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: What is the delivery fee?    </strong>
                        <br />
                        <strong>A:</strong> Our Standard fee is $19.95 per delivery. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: What if I am not there during the delivery time?   </strong>
                        <br />
                        <strong>A:</strong> It is imperative that you do your best to be present during the delivery time you choose. If you are not present during your delivery time, you will be subject to a $15 redelivery charge. If you are not present during your delivery time, or do not attempt to have a redelivery, you will be charged a $30 restocking fee. We will email you a couple of times prior to your order to remind you of your order time and details. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: Do I have to be there to receive my groceries?   </strong>
                        <br />
                        <strong>A:</strong> Yes, you must be there to receive your groceries. If you cannot be there for your groceries, you must contact us immediately. If you have another person that will be accepting your groceries, you must notify us ahead of time. This can be done by contacting us - be sure to include your order number, delivery date, and delivery time. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: If I know I will not be present during the delivery time, can I instruct the driver to leave my groceries somewhere? </strong>
                        <br />
                        <strong>A:</strong> We do not currently do grocery drop-offs. If you would like to have a neighbor, friend or roommate sign for you, please contact us and let us know. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: Can I have my groceries delivered to a different address than my own? 
                        </strong>
                        <br />
                        <strong>A:</strong> Yes. During the checkout process you will be asked for your delivery address. Simply change this address to the one you wish to have the delivery. Your selection will be delivered to the location you enter. 
                    </td>
                </tr>               
                <tr>
                    <td class="formTextUser">
                        <strong>Q: Do I have to tip the driver?   </strong>
                        <br />
                        <strong>A:</strong> Leaving tips is entirely up to you. Tips are not expected, but are always appreciated by our employees.
                    </td>
                </tr>              
                <tr>
                    <td class="formTextUser">
                        <strong>Q: Do you deliver to students?  </strong>
                        <br />
                        <strong>A:</strong> Yes! Anyone can take advantage of our service. We deliver to anyone living in the campus area. We deliver to all locations within the zip codes located on our home page. If you are unsure if we will deliver to your location, simply fill out the online <a href="ContactUsPage.aspx" class="Userlink1">Contact Us</a> form and we will communicate with you when we begin delivering in your area. 
                    </td>
                </tr>
             <tr>
                    <td align="left" class="formHeadingNew">
                        <a name="customerservice"></a>Customer Serive
                    </td>
                </tr>
             <tr>
                 <td class="formTextUser">
                     <strong>Q: What if I am missing an item? </strong>
                     <br />
                     <strong>A:</strong> Please contact us immediately if you feel you are missing an item from your order. We will locate the item and bring it to you immediately. After 48 hours, we can no longer be responsible for missing items. We double check all orders when they are picked up and before they are delivered. It is extremely important for us to know if we made any mistakes so we can fix them. 
                 </td>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: How do I contest a charge on my credit card?  </strong>
                        <br />
                        <strong>A:</strong>  If you feel there is an incorrect charge on your credit card, please contact us immediately. We will work with you to identify the charge and settle any issues quickly. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q:  There is a problem with my groceries, what should I do? </strong>
                        <br />
                        <strong>A:</strong> We handle all customer complaints seriously. Please contact us immediately if you have any concerns about your groceries. Please understand you must contact us within 24 hours after your delivery if you have a concern about the freshness of our groceries. We require you to contact us within 48 hours if you feel an item is missing. Our business rests entirely on delivering the highest quality of groceries so we always want to know if you are ever unhappy with your order. 
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formHeadingNew">
                        <a name="general"></a>Ordering
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q:  I want an item that is not on the Valet Grocery site, what do I do? </strong>
                        <br />
                        <strong>A:</strong> If you are looking for an item, but don't see it in our store, click the <a class="Userlink1" href="SuggestProduct.aspx">suggest a product </a>link, type in the items that you are looking for and we will do our best to add it to our online store. Once you submit this information you should receive an e-mail within 24 hours letting you know that the item is available and ready to be added to your next order. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: What types of payment do you accept? 
                        </strong>
                        <br />
                        <strong>A:</strong> We accept American Express, Discover, Master Card, Visa, and withdrawals from your Shopping Funds. You can determine which method you wish to use during the checkout process. Click here for a more detailed explanation of our <a class="Userlink1" href="AccountFunds.aspx">Shopping Funds. </a>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: I just placed an order with my credit card and noticed the pending charge was slightly higher than the actual order, why is this? </strong>
                        <br />
                        <strong>A:</strong> Customers often choose the convenience of leaving a tip for the delivery driver on their credit/debit card. In order for Valet Grocery to be able to accept tips, we must place a pending charge above the order total at the time your order is placed. Once your order is delivered, the transaction will be settled for the exact amount you choose when you sign your receipt. 
                    </td>
                </tr>
                <tr>
                <td class="formTextUser">
                    <strong>Q : My credit card got denied - I double checked the number and expiration date, and I know for sure there is enough credit on my card. What gives? </strong>
                <br />
                        <strong>A:</strong> If you entered in the number and the expiration date correctly, your card may have been denied because the billing address you supplied us with does not match the address on file with your credit card company. Some credit card companies will not authorize the transaction unless we have the correct address - it's for your own security.                 
                </td>
                </tr>
                <td class="formTextUser">
                    <strong>Q : Can I change my order after it has been placed?  </strong>
                <br />
                        <strong>A:</strong>If you wish to change an order, please contact us with the items you would like to change. We will accept any order changes prior to 8pm the day before your delivery date.                 
                </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: How do I cancel an order?</strong>
                        <br />
                        <strong>A:</strong> Canceling an order can be completed by contacting us and stating your name, order number, and request for cancellation. Orders can only be cancelled prior to 8pm the day before the delivery date. 
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formHeadingNew">
                        <a name="general"></a>Membership
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q:  What do I need to become a member?  </strong>
                        <br />
                        <strong>A:</strong> You will have to submit your name, email address, contact and delivery information, and an active debit/credit card to become a member. Your information will not be traded or sold and your credit card will not be charged unless you request or you purchase groceries and are not present during delivery and redelivery. See below for more information. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: If membership is free, why do I need to put a debit/credit card down?  </strong>
                        <br />
                        <strong>A:</strong> We require a debit/credit card for all members to protect our business. In rare cases where a significant amount of groceries are purchased and a customer is unavailable for delivery, we are left with significant losses; having your information on file helps protect us from these rare cases. Your credit card will only be charged upon your request or for restocking fees if you are not present during your chosen delivery time. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: How do I cancel my membership? </strong>
                        <br />
                        <strong>A:</strong> <a href= "ContactUsPage.aspx" target="_self">Contact Us</a> if you would like to cancel your membership. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q:How do I change my profile? </strong>
                        <br />
                        <strong>A:</strong> Changing your profile requires you to be signed in. Once signed in, simply click the "My Account" tab on top of our website to access and edit your profile. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q:How do I change my profile? </strong>
                        <br />
                        <strong>A:</strong>  Click here to<a href="LoginPage.aspx" target="_self"> retrieve your username and password. </a>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formHeadingNew">
                        <a name="general"></a>Grocery Questions
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: Do you have a minimum order amount?   </strong>
                        <br />
                        <strong>A:</strong> Yes, our minimum order amount is $75. You will not be able to checkout until your shopping cart amount is above $75. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: How do I know my groceries are fresh?   </strong>
                        <br />
                        <strong>A:</strong> We require a debit/credit card for all members to protect our business. In rare cases where a significant amount of groceries are purchased and a customer is unavailable for delivery, we are left with significant losses; having your information on file helps protect us from these rare cases. Your credit card will only be charged upon your request or for restocking fees if you are not present during your chosen delivery time. 
                    </td>
                </tr>
                 <tr>
                    <td class="formTextUser">
                        <strong>Q:How do you select your groceries?  </strong>
                        <br />
                        <strong>A:</strong> Valet Grocery has specialized employees shopping for you. Our shoppers slowly and carefully choose only the best fruit, vegetables, and other perishables for you. Our employees understand the only way to keep customers coming back is providing them with the best groceries possible. We spend extra time ensuring your perishables are of extremely high quality. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q:Where do your groceries come from?  </strong>
                        <br />
                        <strong>A:</strong>  We currently shop at a number of grocery stores in the area. Our shoppers search for the highest quality groceries they can find. Our goal is to offer you the largest selection of high quality groceries at the best price. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q:What do you do if an item is out of stock?  </strong>
                        <br />
                        <strong>A:</strong> We attempt to get every single item on your list. At times, the items you choose may be out of inventory. If this is the case, we will purchase an equivalent item and adjust the price lower if necessary. If the substituted item is more expensive we will pay the difference 
                    </td>
                </tr>             
                 <tr>
                    <td align="left" class="formHeadingNew">
                        <a name="Security & Privacy"></a>Security & Privacy
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: Do you sell or trade my personal information?  </strong>
                        <br />
                        <strong>A:</strong> No we do not.  We value your privacy and ensure your information is protected and only used internally to improve your experience.  Your information can only be accessed when you sign in or by request.
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: What is ValetGrocery Privacy Policy?   </strong>
                        <br />
                        <strong>A:</strong> Read our <a href="privacy.aspx" class="Userlink3">Privacy Policy</a>.
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: How do I know my order is secure?   </strong>
                        <br />
                        <strong>A:</strong> At Valet Grocery, we want you to feel safe while shopping with us. That's why we use the THAWTE brand to verify our standing. THAWTE verifies our address and business standing for your comfort. In addition they encrypt all of your personal information, including name, address and credit card number, as it is submitted to our Webserver. Once received, your personal information is stored in our providers secure data center. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Q: Can I give you feedback/suggestions?   </strong>
                        <br />
                        <strong>A:</strong> We love to hear what you have to say about any facet of our business and encourage you to let us know any thoughts you have about Valet Grocery and the service that we provide, good or bad.  <a href="SuggestProduct.aspx" class="Userlink3">Click here</a> to send us any comments, suggestions, or feedback.  
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
