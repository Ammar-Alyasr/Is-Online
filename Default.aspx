<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE HTML>
<html>
<head runat="server">
<title>Is Online! - MSKU</title>
<!-- Custom Theme files -->
<link href="css/style.css" rel="stylesheet" type="text/css" media="all"/>
<!-- Custom Theme files -->
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /> 
<meta name="keywords" content="" />
<!--script-->
<script src="js/jquery.min.js"></script>
<script src="js/easyResponsiveTabs.js" type="text/javascript"></script>
		    <script type="text/javascript">
			    $(document).ready(function () {
			        $('#horizontalTab').easyResponsiveTabs({
			            type: 'default', //Types: default, vertical, accordion           
			            width: 'auto', //auto or any width like 600px
			            fit: true   // 100% fit in a container
			        });
			    });
				
</script>	


</head>
<body>  <form id="form1"     runat="server">
   
        
	<div class="head">
		<div class="logo">
			<div class="logo-top">
				<h1>Muğla Sıtkı Koçman Üniversitesi</h1>
			</div>
			<div class="logo-bottom">
				<section class="sky-form">									
					<label ><i></i>Is online'da </label>
					<label ><i></i>tüm siteleri kontrol ederek</label>										
					<label ><i></i>her zaman haberdar olun..</label>
				</section>
			</div>
		</div>		
         
                 <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
		<div class="login">
			<div class="sap_tabs">
				<div id="horizontalTab" style="display: block; width: 100%; margin: 0px;">
					<ul class="resp-tabs-list">
						<li class="resp-tab-item" aria-controls="tab_item-0" role="tab"><span>Login</span></li>
						<%--<li class="resp-tab-item" aria-controls="tab_item-1" role="tab"><label>/</label><span>Sign up</span></li>--%>
						<div class="clearfix"></div>
					</ul>				  	 
					<div class="resp-tabs-container">
						<div class="tab-1 resp-tab-content" aria-labelledby="tab_item-0">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
							<div class="login-top">
                               
                                    
                                    <asp:TextBox ID="TextBox1Em"   placeholder="Email" runat="server"></asp:TextBox>

                                    <asp:TextBox ID="TextBox1Pas"  placeholder="Password" type ="password"   runat="server"></asp:TextBox>
                              
                                <div class="account" >                 
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>                               
                                </div>
								<div class="login-bottom login-bottom1">
                                    <div class="submit">
                                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1"  Text="Giriş" />
                                    </div>

                                    <div class="clear"></div>
								</div>	

                                </ContentTemplate>
       <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
							</div>
						</div>
                 
													
					</div>	
				</div>
			</div>	
		</div>	
		
		
		
		<div class="clear"></div>
	</div>	

            

<%--	<div class="footer">
		<p>
             
             <li><p>Ammar Tarafindan Geliştirildi  <a href="https://www.facebook.com/">fb</a></p></li>
            <div class="clear">
                <br />
                 </div>
		</p>
	</div>--%>
            
    </form>
</body>
</html>