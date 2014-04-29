# ClubManager

## Club Manager application using C# and MongoDB

> We will keep updating the document as we proceed.

**Synopsis**

We will be creating a windows application named “Club Membership” in C# using MongoDB as our active database. This application can be used at any subscription based scenario, e.g.

* Gym
* Sports Complex
* Clubs

This application will be used by the administrator (or clerk) of the organization and will have following functionalities:

* Create Membership Plan and define their fee
* Edit Membership properties and fee
* List all the membership plans available
* Functionality to add new member
* Update member details
* View all the available members
* Search for members using different criteria
* Store custom properties of the members
* View all the members whose fee are due
* View all the members whose fee are about to be due in next n days
* Collect fee


<hr />
**Technical Discussion**

Let us now discuss on some of the technical aspects regarding what all technologies we will be using and how the project is going to be organized. Firstly you should be aware that this is going to be a windows application and not a web application as some of you might be thinking. We will be using .Net Framework for our front end design and MongoDB for our database. Choice of .Net Framework and MongoDB is purely random and does not have any logical reason apart from learning. You can use Java, PHP for your front end design and MySQL, MSSQL, Sybase, Oracle, etc for your database.

So we are using:

* Microsoft Visual Studio 2010 (for IDE)
* C# .Net Framework 3.5 (as our coding language)
* MongoDB (as our database)

Following are the major namespaces that we will be using and may contain further sub-namespaces:

* Core: To contain all the generic app independent code.
* ClubManager: To contain all the Club Membership app related code.

This application will be divided in multiple projects separating different layers, aspects or concerns and will be evident soon. We will use ‘.’ to separate part of names in our projects, e.g. **<sup>1</sup>**

* Core
* Core.ConfigManager
* Core.Data
* Core.Data.Mongo
* ClubManager
* ClubManager.Data
* ClubManager.Model

> **<sup>1</sup>** We will discuss what these projects are doing later.

<hr />
<p style="text-align: center;">**Core Concepts**</p>

**C#** : We will discussing some .Net (applicable to C#) concepts like Extension Methods, Static Constructors, Abstract classes, etc first and then dive into coding. We will also highlight them back as and when the same is used in the code.

**Abstract Classes**
Abstract classes are something in between interface and classes. Abstract classes can have one or more abstract methods (which are not defined, same as method signatures in interfaces) along-with fully defined methods (methods having definition). Now you may ask why use abstract classes when we have interface and classes doing their jobs sincerely. Let us understand this requirement in reverse.

We will suppose an abstract class having 2 implemented and 2 unimplemented methods for following example.

Why not use interface instead of abstract classes. If we use interface and 5 classes are implementing this interface then they will duplicating code for implemented method five times, against the philosophy of code reuse. Using abstract class lets them define methods which base can happily do.

Why not use classes instead of abstract classes. If we use class then we can not leave any method unimplemented. You certainly can debate on using one interface (I) and one class (C) for this purpose. But one point is still left a child can leave interface (I) altogether and go with inheriting class (C) only. When you use abstract class you simply can not instantiate it (ie can not say new AbstractClass()).

e.g. code of an abstract class:

<hr />
<p style="text-align: center;">**Setting up the solution**</p>

**Create solution “ClubManager”**
Fire your visual studio (Microsoft Visual Studio 2010 in our case). We are going to name our application ClubManager and same will be our solution name. Our application is a windows form application. So let us create one.

* Go to File-&gt;New-&gt;Project-&gt;Visual C#-&gt;Windows-&gt;Windows Form Application
* Name it ClubManager
* Leave Create directory for solution checked

**Create solution folders**
We said that we will be manage our solution in multiple solution folders. So let us add<sup>2</sup> some as given below:

* Core: To contain core projects which are independent of ClubManager application but will be used in ClubManager and other future applications.
* Data: To conatin Data Access Layer projects from Core and ClubManager.
* Model: To contain Business Model of the application.
* App: To contain main applications. ClubManager in current case.
* Reference: To contain third party dlls which will be referenced in other projects.

<blockquote><sup>2</sup>To add solution folder: Right Click Solution-&gt;Add-&gt;New Solution Folder</blockquote>
Move (Drag and Drop) ClubManager project in App folder created above. So our solution is all set and we can start coding.

<hr />
<p style="text-align: center;">**Discussing Dependency**</p>

You might have already discovered that we are mainly dealing with Member, MemberShipPlan and Fee in this application as our data collection. If you have not figured that out till now, please read previous contents again and ponder on them.

If we discuss how these 3 collection depend on each other we can deduce that:

* Every Member chooses a MemberShip Plan.
* Every Fee is paid by some member.
* Which means that One MemberShipPlan can be opted by multiple Members which in turn are going to pay Fee multiple time.

But why are we discussing this? This discussion has given us an idea on how we should proceed with our application.

* First we create MemberShipPlan
* We list, edit MemberShipPlan
* We create new Member
* We list, edit Member
* We submit Fee and issue a receipt


<hr />
<p style="text-align: center;">**Create MemberShipPlan**</p>

So what are all the properties of MemberShipPlan that we require:

* MemberShip : Name of MemberShip e.g. Gold, Platinum
* Description : A brief description of the plan
* MonthlyFee : Fee of the plan if paid monthly.
* QuarterlyFee : Fee of the plan if paid quarterly.
* HalfYearlyFee : Fee of the plan if paid half yearly.
* AnnualFee : Fee of the plan if paid annually.


Please note that in general fee is paid monthly, quarterly, Semi-Annually or Annually so we are storing them in individual properties. But we will also accept the fee for 2, 4, 5, 7, 8, 10, 11 months if user wants to.

Apart from above we also need to maintain if the plan is active or not, and some unique id for the Plan which can later be referred. So some more properties:

* _id : Plan ID<sup>3</sup>
* IsActive : If plan is active or not.

<blockquote><sup>3</sup>We use _id everywhere as object identifier.</blockquote>
<ol>
* Now let us add a new Class Library project in **Model** solution folder with name ClubManager.Model.
* Once added the project delete Class1.cs from the new created project and add a new class MemberShipPlan.cs.
* Now add all the properties discussed about Model above in the class file.
* Override ToString() and return Name as this is what we would like to see whenever we call MemberShipPlanObject.ToString()
* Organize the file using regions for easy navigation.
</ol>
Find below complete code of this file:

<code>ClubManager.Model.MemberShipPlan.cs</code>
<pre lang="csharp">namespace ClubManager.Model
{
    /// <summary>
    /// Member Ship Plan
    /// </summary>
    public class MemberShipPlan
    {
        #region Properties

        /// <summary>
        /// Name of MemberShip e.g. Gold, Platinum
        /// </summary>
        public string MemberShip { get; set; }

        /// <summary>
        /// A brief description of the plan
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Fee of the plan if paid monthly.
        /// </summary>
        public double MonthlyFee { get; set; }

        /// <summary>
        /// Fee of the plan if paid quarterly.
        /// </summary>
        public double QuarterlyFee { get; set; }

        /// <summary>
        /// Fee of the plan if paid half yearly.
        /// </summary>
        public double HalfYearlyFee { get; set; }

        /// <summary>
        /// Fee of the plan if paid annually.
        /// </summary>
        public double AnnualFee { get; set; }

        /// <summary>
        /// MemberShip Plan ID
        /// </summary>
        public string _id { get; set; }

        /// <summary>
        /// If plan is active or not.
        /// </summary>
        public bool IsActive { get; set; }

        #endregion Properties

        #region Overridden Methods

        /// <summary>
        /// String representation of the Member Ship Plan
        /// </summary>
        /// <returns>Name of the Plan</returns>
        public override string ToString()
        {
            return this.MemberShip;
        }

        #endregion Overridden Methods
    }
}</pre>
So our Model for MemberShipPlan is now ready and we can design our UI to Create New MemberShipPlan. But wait how should user invoke New MemberShipPlan.

Since it is a windows application we will be having a menu bar containing all the menu options and one of them would be New Plan under MemberShipPlan. So let us go ahead.

* First of all Add a New Item -> MDI Parent Form named frmMain to our ClubManager Project.
* Delete Form1.cs as we are not going to use this empty form.
* Open Program.cs and change Application.Run(new **Form1**()); to Application.Run(new **frmMain**());
* When you view frmMain in designer view you will see a lot of menu items viz File, Edit, View, etc which we do not require at all. So delete them one by one.
* You should also delete all the icons from toolStrip just below MenuItem.
* Once empty let us Create a New Menu Item "Membership Plan" and under it create another item "New Plan". Great we have created menu item.

Now double click New Plan to create click handler and it will bring you to code behind which currently is containing a lot of code and most of them we do not require. So delete them one by one and in the end it will have only below code :
<code>ClubManager.frmMain.cs</code>
<pre lang="csharp">
using System;
using System.Windows.Forms;

namespace ClubManager
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void newPlanToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}
	}
}
</pre>

Github : <a href="https://github.com/techphernalia/ClubManager/tree/83cb6065c5fe860dd330605fd95557f30fa0a35d" title="Browse this commit on Github" target="_blank" >https://github.com/techphernalia/ClubManager/tree/83cb6065c5fe860dd330605fd95557f30fa0a35d</a>

Let us create our view for MemberShipPlan. Since we do not have a lots of fields in MemberShipPlan we will be creating, editing and listing all the MemberShipPlan in single view and name the form frmMemberShipPlan.

Add a new form (Add -> Windows Form) in ClubManager Project and name it frmMemberShipPlan.

As per the discussion on Model MemberShipPlan we require TextBoxes for 6 fields viz	Name, Description and 4 to accept fee, we also require a ComboBox to save if Plan is active or not. We also have appropriate labels for all the fields. Since we will be listing all the Plans on this form itself so we require a DataGridView as well.

Let us drag and drop these components on newly created form and set properties as below :

Label : Name = lbl<PropertyName>, Text = <PropertyName>
TextBox : Name = txt<PropertyName>
CheckBox : Name = chk<PropertyName>
DataGridView : Name = dgvMemberShipPlan, Anchor = "Top, Bottom, Left, Right"
GroupBox : Name = grpPlanDetails, Text = MemberShipPlan Details, Anchor = "Top, Left, Right"
txtDescription : MultiLine = true, ScrollBars = Both, WordWrap = False, Anchor = "Top, Left, Right"
frmMemberShipPlan : Text = MemberShipPlan

Also set the Tab orders accordingly and arrange all the fields beautifully.

Please note : Anchor property specifies how the components behaves when form is resized. On Resize corresponding distance between form border and control border will remain fixed.

Now here comes the question how are we going to maintain New and Edit on same form? We will be maintaining a private MemberShipPlan variable in the form to track if form is open in new or edit form. So first add reference to project ClubManager.Model and initialize a private MemberShipPlan variable MemberShipPlanBeforeEdit to null.

Next we code click event of btnReset where we check MemberShipPlanBeforeEdit for null and set the form components accordingly.
<pre lang="csharp">
private void btnReset_Click(object sender, EventArgs e)
{
	if (MemberShipPlanBeforeEdit != null)
	{
		txtMemberShip.Text = MemberShipPlanBeforeEdit.MemberShip.ToString();
		txtDescription.Text = MemberShipPlanBeforeEdit.Description.ToString();
		txtMonthlyFee.Text = MemberShipPlanBeforeEdit.MonthlyFee.ToString();
		txtQuarterlyFee.Text = MemberShipPlanBeforeEdit.QuarterlyFee.ToString();
		txtHalfYearlyFee.Text = MemberShipPlanBeforeEdit.HalfYearlyFee.ToString();
		txtAnnualFee.Text = MemberShipPlanBeforeEdit.AnnualFee.ToString();
		chkIsActive.Checked = MemberShipPlanBeforeEdit.IsActive;
	}
	else
	{
		txtMemberShip.Text = txtDescription.Text = txtMonthlyFee.Text = txtQuarterlyFee.Text = txtHalfYearlyFee.Text = txtAnnualFee.Text = "";
		chkIsActive.Checked = true;
	}
</pre>

This form can be viewed in New and Edit mode so let us create 2 public methods to handle the same:
<pre lang="csharp">
public void NewPlan()
{
	MemberShipPlanBeforeEdit = null;
	btnReset_Click(null, null);
	this.Show();
	this.Focus();
}

public void EditPlan(MemberShipPlan MemberShipPlan )
{
	MemberShipPlanBeforeEdit = null;
	btnReset_Click(null, null);
	this.Show();
	this.Focus();
}
</pre>		
========================================================================================
		
Now we need to persist and retrieve data from database but we have not configured the same. Let us do that next.

We will soon come to know that we will be requiring a lot of configuration values for Database(Host, Port, UserName, Password, DBName), Application(Title) and so on and if we store al the configuration in our app.config it will make our application quite dirty, so we decide to keep a key in our app.config which will refer to a xml file from where we can read our configuration values. Let us create a framework for us to deal with the same.

We read Config xml in a class and hold all the nodes over there, other ask for their node and process them as required. If none of the configuration is required why read the file at all, so we will use static constructors to lazy read the configuration.

Add a new class library project named Core.Configuration, delete Class1.cs from the project and add a reference to System.Configuration. Once done add a new class file ConfigurationManager.cs.
We define AppConfig as our required configuration xml key and store configuration xml in Dictionary<string, XElement> object named ConfigValue.
We iterate the document and add each node under root to the configuration value and we are done. A really very short code to do exactly what we need, shared below:

<pre lang="csharp">
using System.Collections.Generic;
using System.Xml.Linq;

namespace Core.Configuration
{
	public class ConfigurationManager
	{
		#region Configuration Values
		public static Dictionary<string, XElement> ConfigValue = new Dictionary<string, XElement>();
		#endregion Configuration Values

		#region XML Configuration Keys

		private static string APP_CONFIG = "AppConfig";

		#endregion XML Configuration Keys

		#region Constructors

		static ConfigurationManager()
		{
			XDocument XDoc = XDocument.Load(System.Configuration.ConfigurationManager.AppSettings[APP_CONFIG]);

			foreach (XElement ele in XDoc.Root.Elements())
				ConfigValue.Add(ele.Name.LocalName, ele);
		}

		#endregion Constructors
	}
}
</pre>

Github : <a href="https://github.com/techphernalia/ClubManager/tree/9614cc3693833eabd2eb1fdeed7365708f6502df" title="Browse this commit on Github" target="_blank" >https://github.com/techphernalia/ClubManager/tree/9614cc3693833eabd2eb1fdeed7365708f6502df</a>