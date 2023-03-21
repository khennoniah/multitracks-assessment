<%@ Page Language="C#" AutoEventWireup="true" CodeFile="artistAlbums.aspx.cs" Inherits="artistDetails" %>

<!DOCTYPE html>
<html lang="en">
	<head>
		<!-- set the viewport width and initial-scale on mobile devices -->
		<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no" />

		<!-- set the encoding of your site -->
		<meta charset="utf-8">
		<title>MultiTracks.com</title>
		<!-- include the site stylesheet -->
	    <link rel="icon" href="https://mtracks.azureedge.net/public/images/icon/favicon/favicon-32x32.png" type="image/png">
		<link rel="icon" href="https://mtracks.azureedge.net/public/images/icon/favicon/favicon-svg2.svg" type="image/svg+xml">
		<meta name="theme-color" content="#ffffff">
		<link media="all" rel="stylesheet" href="https://mtracks.azureedge.net/public/css/v22/main.min.css?v=4">
		<style type="text/css">.is-slide-hidden{position:absolute;left:-9999px;top:-9999px;display:block;}</style>

	</head>

	<body class="premium standard u-fix-fancybox-iframe">
		<form>
			<noscript>
				<div>Javascript must be enabled for the correct page display</div>
			</noscript>

			<!-- allow a user to go to the main content of the page -->
			<a class="accessibility" href="#main" tabindex="21">Skip to Content</a>

			<div class="wrapper mod-standard mod-gray">
				<div class="details-banner">
					<div class="details-banner--overlay"></div>

					<div class="details-banner--hero">
						<asp:Image runat="server" ID="hero" 
							class="details-banner--hero--img" />
					</div>

					<div class="details-banner--info">
						<a href="#" class="details-banner--info--box">
							<asp:Image runat="server" ID="info_box" 
								CssClass="details-banner--info--box--img" 
								AlternateText="alt"/>
						</a>
						<h1 class="details-banner--info--name">
							<%-- TODO: could wrap asp:Literal in <a> tag like above? --%>
							<asp:HyperLink runat="server" ID="name_link"  
								CssClass="details-banner--info--name--link" 
								NavigateUrl="#"/> 
						</h1>
					</div>
				</div>

				<nav class="discovery--nav">
					<ul class="discovery--nav--list tab-filter--list u-no-scrollbar">
						<li class="discovery--nav--list--item tab-filter--item">
							<a class="tab-filter" href="artistDetails.aspx?artistID=<%=Request.QueryString["artistID"] %>">Overview</a>
						</li>
						<li class="discovery--nav--list--item tab-filter--item">
							<a class="tab-filter" href="artistSongs.aspx?artistID=<%=Request.QueryString["artistID"] %>">Songs</a>
						</li>
						<li class="discovery--nav--list--item tab-filter--item is-active">
							<a class="tab-filter">Albums</a>
						</li>
					</ul> <!-- /.browse-header-filters -->
				</nav>

				<div class="discovery--container u-container">
							<main class="discovery--section">

								<div class="discovery--space-saver">
									<section class="standard--holder">
										<div class="discovery--section--header">
											<h2>Albums</h2>
										</div><!-- /.discovery-select -->

										<div class="discovery--grid-holder">

											<div class="ly-grid ly-grid-cranberries">

												<asp:Repeater runat="server" ID="albums">
													<ItemTemplate>
															<div class="media-item">
																<a class="media-item--img--link" href="#" tabindex="0">
																	<asp:Image runat="server" ID="album"
																		ImageUrl=<%#Eval("imageUrl")%>
																		AlternateText=<%#Eval("title")%>
																		CssClass="media-item--img"/>
																	<span class="image-tag">Master</span>
																</a>
																<a class="media-item--title" href="#" tabindex="0"><%#Eval("title")%></a>
																<a class="media-item--subtitle" href="#" tabindex="0"><%#Eval("artistName")%></a>
															</div>
													</ItemTemplate>
												</asp:Repeater>

											</div><!-- /.grid -->
										</div><!-- /.discovery-grid-holder -->
									</section><!-- /.songs-section -->
								</div>
							</main><!-- /.discovery-section -->
				</div><!-- /.standard-container -->
			</div><!-- /.wrapper -->

			<%--#include virtual = "./includes/footer.aspx"--%> 
			

			<a class="accessibility" href="#wrapper" tabindex="20">Back to top</a>
		</form>
	</body>
</html>

