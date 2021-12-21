﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Users/Seller.master" AutoEventWireup="true" CodeBehind="Seller.aspx.cs" Inherits="OnlineStore.Pages.Users.Seller1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content4" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content5" runat="server">
    <h1>Welcome to Seller Page</h1>
    <ul class="main-nav">
  <li class="item1">
    <div class="bg"></div>
  </li>
  <li class="item2">
    <div class="bg"></div>
  </li>
  <li class="item3">
    <div class="bg"></div>
  </li>
  <li class="item4">
    <div class="bg"></div>
  </li>
  <li class="item5">
    <div class="bg"></div>
  </li>
</ul>
    <style>
        * {
  margin: 0;
  padding: 0;
  background-color: #000;
  font-family: poppins, sans-serif;
}

.main-nav {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  margin: 0;
  padding: 0;
  width: 600px;
  height: 150px;
}

.main-nav li {
  list-style: none;
  position: absolute;
  width: 200px;
  height: 200px;
  background: #000;
  transform: rotate(45deg);
  transition: 0.5s;
  margin: -100px;
  overflow: hidden;
  opacity: 0.5;
}

.main-nav li:hover {
  opacity: 1;
}

.main-nav li.item1 {
  top: 0;
  left: 0;
}

.main-nav li.item2 {
  bottom: 0;
  left: 25%;
}

.main-nav li.item3 {
  top: 0;
  left: 50%;
}

.main-nav li.item4 {
  bottom: 0;
  left: 75%;
}

.main-nav li.item5 {
  top: 0;
  left: 100%;
}

.main-nav li .bg {
  width: 100%;
  height: 100%;
  transform: scale(1.1);
}

.main-nav li.item1 .bg {
  background: url(https://imgur.com/ir9l1IJ.jpg);
  background-size: cover;
  background-position: center;
}

.main-nav li.item2 .bg {
  background: url(https://imgur.com/fwe8Z9Q.jpg);
  background-size: cover;
  background-position: center;
}

.main-nav li.item3 .bg {
  background: url(https://imgur.com/kSoRoDk.jpg);
  background-size: cover;
  background-position: center;
}

.main-nav li.item4 .bg {
  background: url(https://imgur.com/sz1BSkB.jpg);
  background-size: cover;
  background-position: center;
}

.main-nav li.item5 .bg {
  background: url(https://imgur.com/ara0hoV.jpg);
  background-size: cover;
  background-position: center;
}

    </style>
</asp:Content>
