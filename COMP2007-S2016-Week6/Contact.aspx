<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="COMP2007_S2016_Week6.Contact" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-6 text-center">
                <h1>Contact Us</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="panel panel-primary">
                    <div class="panel-heading">Contact Info</div>
                        <div class="panel-body">
                            <address>
                                <strong>Chad Ostler</strong><br>
                                1 Toronto Street<br>
                                Barrie, On L9L 9L9<br>
                                <abbr title="Phone">P:</abbr>
                                (705) 555-6666
                            </address>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="control-label" for="FirstNameTextBox">First Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="FirstNameTextBox" placeholder="First Name" required="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" CssClass="alert-danger" ErrorMessage="First Name Required" ControlToValidate="FirstNameTextBox"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label class="control-label" for="LastNameTextBox">Last Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="LastNameTextBox" placeholder="Last Name" required="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" CssClass="alert-danger" ErrorMessage="Last Name Required" ControlToValidate="LastNameTextBox"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label class="control-label" for="EmailTextBox">Email</label>
                    <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" ID="EmailTextBox" placeholder="name@email.com" required="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" CssClass="alert-danger" ErrorMessage="Email Required" ControlToValidate="EmailTextBox"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label class="control-label" for="ContactNumberTextBox">Phone</label>
                    <asp:TextBox runat="server" TextMode="Phone" CssClass="form-control" ID="ContactNumberTextBox" placeholder="(123)456-789" required="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" CssClass="alert-danger" ErrorMessage="Contact Number Required" ControlToValidate="ContactNumberTextBox"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label class="control-label" for="MessageTextBox">Message</label>
                    <asp:TextBox runat="server" TextMode="MultiLine" Rows="3" Columns="3" CssClass="form-control" ID="MessageTextBox" placeholder="Your message goes here..." required="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" CssClass="alert-danger" ErrorMessage="Message Required" ControlToValidate="MessageTextBox"></asp:RequiredFieldValidator>
                </div>
                <div class="text-right">
                    <a class="btn btn-warning btn-lg" id="CancelButton" href="Default.aspx">Cancel</a>
                    <asp:Button Text="Send" CssClass="btn btn-primary btn-lg" runat="server" ID="SendButton" CausesValidation="true" OnClick="SendButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
