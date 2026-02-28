<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DemoApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div  style="text-align:center; background-color:aqua">
            <h1>LPU Registration Form</h1>
            <br />
            <input id="name" type="text" placeholder="Name *" />
            <br />
            <input id="email" type="email" placeholder="Enter Email *" />
            <br />
            <input id="phone" type="number" placeholder="Mobile Number *" />
            <input id="otp" type="number" placeholder="Enter OTP *" />
            <br />
            <input id="state" type="text" placeholder="State *" />
            <input id="city" type="text" placeholder="City *" />
            <br />
            <input id="qualification" type="text" placeholder="Qualification *" />
            <input id="descipline" tpye="text" placeholder="Discipline interested in *" />
            <br />
            <input type="checkbox" id="checkbox" />
            <p>I authorize Lovely Professional University to contact me <br /> with updates and notifications via Email, SMS, <br />Whatsapp and Call. This will override the registry on <br />DND / NDNC. *</p>
            <input id="Submit1" type="submit" value="APPLY NOW" />
        </div>
    </form>
</body>
</html>
