<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SaifLogic.Dashboard" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <title>SaifLogic</title>
  <!-- plugins:css -->
  <link rel="stylesheet" href="Themes/Portal/V1/assets/vendors/mdi/css/materialdesignicons.min.css">
  <link rel="stylesheet" href="Themes/Portal/V1/assets/vendors/css/vendor.bundle.base.css">
  <!-- endinject -->
  <!-- Plugin css for this page -->
  <link rel="stylesheet" href="Themes/Portal/V1/assets/vendors/flag-icon-css/css/flag-icon.min.css">
  <link rel="stylesheet" href="Themes/Portal/V1/assets/vendors/jvectormap/jquery-jvectormap.css">
  <!-- End plugin css for this page -->
  <!-- Layout styles -->
  <link rel="stylesheet" href="Themes/Portal/V1/assets/css/demo/style.css">
  <!-- End layout styles -->
  <link rel="shortcut icon" href="Themes/Portal/V1/assets/images/favicon.png" />
</head>
<body>
<script src="Themes/Portal/V1/assets/js/preloader.js"></script>
  <div class="body-wrapper">l
    <!-- partial:partials/_sidebar.html -->
    <aside class="mdc-drawer mdc-drawer--dismissible mdc-drawer--open">
      <div class="mdc-drawer__header">
        <a href="index.html" class="brand-logo">
          <img src="Themes/Portal/V1/assets/images/logo.svg" alt="logo">
        </a>
      </div>
      <div class="mdc-drawer__content">
        <div class="user-info">
          <p class="name">Abdul Usmani</p>
          <p class="email">usmani.abdul@saiflogic.com</p>
        </div>
        <div class="mdc-list-group">
          <nav class="mdc-list mdc-drawer-menu">
            <div class="mdc-list-item mdc-drawer-item">
              <a class="mdc-drawer-link" href="dashboard.aspx">
                <i class="material-icons mdc-list-item__start-detail mdc-drawer-item-icon" aria-hidden="true">home</i>
                Dashboard
              </a>
            </div>
			<div class="mdc-list-item mdc-drawer-item">
              <a class="mdc-drawer-link" href="projects.aspx">
                <i class="material-icons mdc-list-item__start-detail mdc-drawer-item-icon" aria-hidden="true">track_changes</i>
                Projects
              </a>
            </div>
			<div class="mdc-list-item mdc-drawer-item">
              <a class="mdc-drawer-link" href="pages/forms/basic-forms.html">
                <i class="material-icons mdc-list-item__start-detail mdc-drawer-item-icon" aria-hidden="true">track_changes</i>
                Kryptonite
              </a>
            </div>
			<div class="mdc-list-item mdc-drawer-item">
              <a class="mdc-drawer-link" href="pages/forms/basic-forms.html">
                <i class="material-icons mdc-list-item__start-detail mdc-drawer-item-icon" aria-hidden="true">track_changes</i>
                User Mgmt
              </a>
            </div>
			<div class="mdc-list-item mdc-drawer-item">
              <a class="mdc-drawer-link" href="CustomerManagement.aspx">
                <i class="material-icons mdc-list-item__start-detail mdc-drawer-item-icon" aria-hidden="true">track_changes</i>
                Customer Mgmt
              </a>
            </div>
            
			
            
            
            
            
          </nav>
        </div>
        <div class="profile-actions">
          <a href="javascript:;">Settings</a>
          <span class="divider"></span>
          <a href="javascript:;">Logout</a>
        </div>

      </div>
    </aside>
    <!-- partial -->
    <div class="main-wrapper mdc-drawer-app-content">
      <!-- partial:partials/_navbar.html -->
      <header class="mdc-top-app-bar">
        <div class="mdc-top-app-bar__row">
          <div class="mdc-top-app-bar__section mdc-top-app-bar__section--align-start">
            <button class="material-icons mdc-top-app-bar__navigation-icon mdc-icon-button sidebar-toggler">menu</button>
            <span class="mdc-top-app-bar__title">Greetings Abdul!</span>
            
          </div>
          <div class="mdc-top-app-bar__section mdc-top-app-bar__section--align-end mdc-top-app-bar__section-right">
            <div class="menu-button-container menu-profile d-none d-md-block">
              <button class="mdc-button mdc-menu-button">
                <span class="d-flex align-items-center">
                  <span class="figure">
                    <img src="http://abdulusmani.com/Themes/assets/images/0-1-200x200.jpg" alt="user" class="user">
                  </span>
                  <span class="user-name">Abdul Usmani</span>
                </span>
              </button>
              <div class="mdc-menu mdc-menu-surface" tabindex="-1">
                <ul class="mdc-list" role="menu" aria-hidden="true" aria-orientation="vertical">
                  <li class="mdc-list-item" role="menuitem">
                    <div class="item-thumbnail item-thumbnail-icon-only">
                      <i class="mdi mdi-account-edit-outline text-primary"></i>
                    </div>
                    <div class="item-content d-flex align-items-start flex-column justify-content-center">
                      <h6 class="item-subject font-weight-normal">Edit profile</h6>
                    </div>
                  </li>
                  <li class="mdc-list-item" role="menuitem">
                    <div class="item-thumbnail item-thumbnail-icon-only">
                      <i class="mdi mdi-settings-outline text-primary"></i>                      
                    </div>
                    <div class="item-content d-flex align-items-start flex-column justify-content-center">
                      <h6 class="item-subject font-weight-normal">Logout</h6>
                    </div>
                  </li>
                </ul>
              </div>
            </div>
            <div class="divider d-none d-md-block"></div>
            
         
            
            <div class="menu-button-container d-none d-md-block">
              <button class="mdc-button mdc-menu-button">
                <i class="mdi mdi-arrow-down-bold-box"></i>
              </button>
              <div class="mdc-menu mdc-menu-surface" tabindex="-1">
                <ul class="mdc-list" role="menu" aria-hidden="true" aria-orientation="vertical">
                 
                  <li class="mdc-list-item" role="menuitem">
                    <div class="item-thumbnail item-thumbnail-icon-only">
                      <i class="mdi mdi-logout-variant text-primary"></i>                      
                    </div>
                    <div class="item-content d-flex align-items-start flex-column justify-content-center">
                      <h6 class="item-subject font-weight-normal">Logout</h6>
                    </div>
                  </li>
                </ul>
              </div>
            </div>
          </div>
        </div>
      </header>
      <!-- partial -->
      <div class="page-wrapper mdc-toolbar-fixed-adjust">
        <main class="content-wrapper">
          <div class="mdc-layout-grid">
            <div class="mdc-layout-grid__inner">
              <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-3-desktop mdc-layout-grid__cell--span-4-tablet">
                <div class="mdc-card info-card info-card--success">
                  <div class="card-inner">
                    <h5 class="card-title">Active Projects</h5>
                    <h5 class="font-weight-light pb-2 mb-1 border-bottom">10</h5>
                    <p class="tx-12 text-muted">$35,000</p>
                    <div class="card-icon-wrapper">
                      <i class="material-icons">dvr</i>
                    </div>
                  </div>
                </div>
              </div>
              <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-3-desktop mdc-layout-grid__cell--span-4-tablet">
                <div class="mdc-card info-card info-card--danger">
                  <div class="card-inner">
                    <h5 class="card-title">Total Projets</h5>
                    <h5 class="font-weight-light pb-2 mb-1 border-bottom">16</h5>
                    <p class="tx-12 text-muted">$125,000</p>
                    <div class="card-icon-wrapper">
                      <i class="material-icons">attach_money</i>
                    </div>
                  </div>
                </div>
              </div>
              <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-3-desktop mdc-layout-grid__cell--span-4-tablet">
                <div class="mdc-card info-card info-card--primary">
                  <div class="card-inner">
                    <h5 class="card-title">Total Customers</h5>
                    <h5 class="font-weight-light pb-2 mb-1 border-bottom">3</h5>
                    <p class="tx-12 text-muted">$45,000</p>
                    <div class="card-icon-wrapper">
                      <i class="material-icons">trending_up</i>
                    </div>
                  </div>
                </div>
              </div>
              <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-3-desktop mdc-layout-grid__cell--span-4-tablet">
                <div class="mdc-card info-card info-card--info">
                  <div class="card-inner">
                    <h5 class="card-title">Average Income</h5>
                    <h5 class="font-weight-light pb-2 mb-1 border-bottom">$7,500.00</h5>
                    <p class="tx-12 text-muted">87% target reached</p>
                    <div class="card-icon-wrapper">
                      <i class="material-icons">credit_card</i>
                    </div>
                  </div>
                </div>
              </div>
              <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-12">
                <div class="mdc-card">
                  <div class="d-flex justify-content-between">
                    <h4 class="card-title mb-0">SaifLogic</h4>
                    
                  </div>
                  
                  <div class="mdc-layout-grid__inner mt-2">
                    
                    
                  </div>
                </div> 
              </div>
              <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-6-desktop mdc-layout-grid__cell--span-4-tablet">
                <div class="mdc-card bg-success text-white">
                  <div class="d-flex justify-content-between">
                    <h3 class="font-weight-normal">New Project</h3>
                    <%--<i class="material-icons options-icon text-white">more_vert</i>--%>
                  </div>
                  <div class="mdc-layout-grid__inner align-items-center">
                    <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-4-desktop mdc-layout-grid__cell--span-3-tablet mdc-layout-grid__cell--span-2-phone">
                      <div>
                        <%--<h5 class="font-weight-normal mt-2">Customers 58.39k</h5>
                        <h2 class="font-weight-normal mt-3 mb-0">636,757K</h2>--%>
                          
                          <a class="mdc-button mdc-button--raised filled-button--light" href="NewProject.aspx">
                
                Add New Project
              </a>

                      </div>
                    </div>
                    <%--<div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-8-desktop mdc-layout-grid__cell--span-5-tablet mdc-layout-grid__cell--span-2-phone">
                      <canvas id="impressions-chart" height="80"></canvas>
                    </div>--%>
                  </div>
                </div>
              </div>
              <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-6-desktop mdc-layout-grid__cell--span-4-tablet">
                <div class="mdc-card bg-info text-white">
                    <div class="d-flex justify-content-between">
                      <h3 class="font-weight-normal">New Customer</h3>
                      <%--<i class="material-icons options-icon text-white">more_vert</i>--%>
                    </div>
                    <div class="mdc-layout-grid__inner align-items-center">
                      <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-4-desktop mdc-layout-grid__cell--span-3-tablet mdc-layout-grid__cell--span-2-phone">
                        <div>
                          <%--<h5 class="font-weight-normal mt-2">Customers 58.39k</h5>
                          <h2 class="font-weight-normal mt-3 mb-0">636,757K</h2>--%>
                            <a class="mdc-button mdc-button--raised filled-button--dark" href="NewCustomer.aspx">
                
                Add New Customer
              </a>
                        </div>
                      </div>
                      <%--<div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-8-desktop mdc-layout-grid__cell--span-5-tablet mdc-layout-grid__cell--span-2-phone">
                        <canvas id="traffic-chart" height="80"></canvas>
                      </div>--%>
                    </div>
                </div>
              </div>
              <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-8">
                <div class="mdc-card">
                  <div class="d-flex justify-content-between align-items-center">
                    <h4 class="card-title mb-2 mb-sm-0">Revenue by location</h4>
                    <div class="d-flex justtify-content-between align-items-center">
                      <p class="d-none d-sm-block text-muted tx-12 mb-0 mr-2">Goal reached</p>
                      <i class="material-icons options-icon">more_vert</i>
                    </div>
                  </div>
                  <div class="d-block d-sm-flex justify-content-between align-items-center">
                    <h6 class="card-sub-title mb-0">Sales performance revenue based by country</h6>
                    <div class="mdc-tab-wrapper revenue-tab mdc-tab--secondary"> 
                      <div class="mdc-tab-bar" role="tablist">
                        <div class="mdc-tab-scroller">
                          <div class="mdc-tab-scroller__scroll-area">
                            <div class="mdc-tab-scroller__scroll-content">
                              <button class="mdc-tab mdc-tab--active" role="tab" aria-selected="true" tabindex="0">
                                <span class="mdc-tab__content">
                                  <span class="mdc-tab__text-label">1W</span>
                                </span>
                                <span class="mdc-tab-indicator mdc-tab-indicator--active">
                                  <span class="mdc-tab-indicator__content mdc-tab-indicator__content--underline"></span>
                                </span>
                                <span class="mdc-tab__ripple"></span>
                              </button>
                              <button class="mdc-tab mdc-tab" role="tab" aria-selected="true" tabindex="0">
                                <span class="mdc-tab__content">
                                  <span class="mdc-tab__text-label">1M</span>
                                </span>
                                <span class="mdc-tab-indicator mdc-tab-indicator">
                                  <span class="mdc-tab-indicator__content mdc-tab-indicator__content--underline"></span>
                                </span>
                                <span class="mdc-tab__ripple"></span>
                              </button>
                              <button class="mdc-tab mdc-tab" role="tab" aria-selected="true" tabindex="0">
                                <span class="mdc-tab__content">
                                  <span class="mdc-tab__text-label">3M</span>
                                </span>
                                <span class="mdc-tab-indicator mdc-tab-indicator">
                                  <span class="mdc-tab-indicator__content mdc-tab-indicator__content--underline"></span>
                                </span>
                                <span class="mdc-tab__ripple"></span>
                              </button>
                              <button class="mdc-tab mdc-tab" role="tab" aria-selected="true" tabindex="0">
                                <span class="mdc-tab__content">
                                  <span class="mdc-tab__text-label">1Y</span>
                                </span>
                                <span class="mdc-tab-indicator mdc-tab-indicator">
                                  <span class="mdc-tab-indicator__content mdc-tab-indicator__content--underline"></span>
                                </span>
                                <span class="mdc-tab__ripple"></span>
                              </button>
                              <button class="mdc-tab mdc-tab" role="tab" aria-selected="true" tabindex="0">
                                <span class="mdc-tab__content">
                                  <span class="mdc-tab__text-label">ALL</span>
                                </span>
                                <span class="mdc-tab-indicator mdc-tab-indicator">
                                  <span class="mdc-tab-indicator__content mdc-tab-indicator__content--underline"></span>
                                </span>
                                <span class="mdc-tab__ripple"></span>
                              </button>
                            </div>
                          </div>
                        </div>
                      </div>
                      <div class="content content--active">    
                      </div>
                      <div class="content">
                      </div>
                      <div class="content">    
                      </div>
                      <div class="content">
                      </div>
                      <div class="content">
                      </div>
                    </div>
                  </div>
                  <div class="chart-container mt-4">
                    <canvas id="revenue-chart" height="260"></canvas>
                  </div>
                </div>
              </div>
              <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-4 mdc-layout-grid__cell--span-8-tablet">
                <div class="mdc-card">
                  <div class="d-flex d-lg-block d-xl-flex justify-content-between">
                    <div>
                      <h4 class="card-title">Order Statistics</h4>
                      <h6 class="card-sub-title">Customers 58.39k</h6>
                    </div>
                    <div id="sales-legend" class="d-flex flex-wrap"></div>
                  </div>
                  <div class="chart-container mt-4">
                    <canvas id="chart-sales" height="260"></canvas>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </main>
        <!-- partial:partials/_footer.html -->
        <footer>
          <div class="mdc-layout-grid">
            <div class="mdc-layout-grid__inner">
              <div class="mdc-layout-grid__cell stretch-card mdc-layout-grid__cell--span-6-desktop">
                <span class="text-center text-sm-left d-block d-sm-inline-block tx-14">Copyright © <a href="https://www.saiflogic.com/" target="_blank">SaifLogic </a>2022</span>
              </div>
              
            </div>
          </div>
        </footer>
        <!-- partial -->
      </div>
    </div>
  </div>
  <!-- plugins:js -->
  <script src="Themes/Portal/V1/assets/vendors/js/vendor.bundle.base.js"></script>
  <!-- endinject -->
  <!-- Plugin js for this page-->
  <script src="Themes/Portal/V1/assets/vendors/chartjs/Chart.min.js"></script>
  <script src="Themes/Portal/V1/assets/vendors/jvectormap/jquery-jvectormap.min.js"></script>
  <script src="Themes/Portal/V1/assets/vendors/jvectormap/jquery-jvectormap-world-mill-en.js"></script>
  <!-- End plugin js for this page-->
  <!-- inject:js -->
  <script src="Themes/Portal/V1/assets/js/material.js"></script>
  <script src="Themes/Portal/V1/assets/js/misc.js"></script>
  <!-- endinject -->
  <!-- Custom js for this page-->
  <script src="Themes/Portal/V1/assets/js/dashboard.js"></script>
  <!-- End custom js for this page-->
</body>
</html> 
