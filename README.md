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

Add App.config(Add->New Item->Application Configuration Project) to main project ClubManager and add a key "AppConfig" with a value "Config.xml".

<pre lang="xml">
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="AppConfig" value="Config.xml"/>
  </appSettings>
</configuration>
</pre>

Next we need to add Config.xml file in the project (Add->New Item->XML File) We will use Club as our Root Node so add the node to file and save it.
<pre lang="xml">
<?xml version="1.0" encoding="utf-8" ?>
<Club>
</Club>
</pre>

We want this Config.xml to be available to us at runtime so we change the "Copy To Output" property of file to "Copy if newer". Build the project and you will find Config.xml in your bin/Debug directory.

Github : <a href="https://github.com/techphernalia/ClubManager/tree/22efc9de7929d171bae217333c5904ba3c9dddf9" title="Browse this commit on Github" target="_blank" >https://github.com/techphernalia/ClubManager/tree/22efc9de7929d171bae217333c5904ba3c9dddf9</a>

As we know key for our Database is "DB" so we need to add node DB to our Config.xml with various nodes as we defined in our Core.Data.Context.cs. Let us go ahead and add these values and find below the final Config.xml after adding required values. We will be using MongoDB as our database so we put Type as Mongo and other properties as applicable.

<pre lang="xml">
<?xml version="1.0" encoding="utf-8" ?>
<Club>
  <DB>
    <Type>Mongo</Type>
    <Host>127.0.0.1</Host>
    <Port>27017</Port>
    <Auth>False</Auth>
    <User></User>
    <Pass></Pass>
    <Name>BodyBuilding</Name>
    <Prefix></Prefix>
    <Suffix></Suffix>
    <Config>MyConfig</Config>
  </DB>
</Club>
</pre>

But we have not yet written any code to interact with MongoDB. We will now code the same. As discussed earlier we will write all Implementation specific database code in separate projects so we add a new Class Library Project Core.Data.Mongo in Core Solution folder. Delete Class1.cs added in the Core.Data.Mongo project and add a new class named Mongo.cs

Since Core.Data.Mongo.Mongo will be extending Core.Data.Context so add a reference to project Core.Data in Core.Data.Mongo and extend Core.Data.Context. We also require MongoDB drivers for MongoDB Connectivity. We download it from official MongoDB website and add the dlls in our Reference folder (We manually create a Reference folder in our filesystem and paste dlls there and then Add->Existing Item->Select both dlls and add it to Solution Folder) and refer it in Core.Data.Mongo project from References folder.

We should first create a MongoDatabase instance and store it so that other methods can use the same. For demonstration purpose only we will connect with an instance which is not password protected and later on update it to support password protected instances as well. We are doing all this in static constructor so that DB instance is created automatically as soon as it is required.

<pre lang="csharp">
#region Private Objects
private static MongoDatabase _DB = null;
#endregion

#region Constructors
static Mongo()
{
	_DB = new MongoServer
	(
		new MongoServerSettings
		{
			Server = new MongoServerAddress(Host, Port)
		}
	).GetDatabase(DBName);
}
#endregion Constructors
</pre>

Next we add code to ListAll() the documents: First we get Collection, Find All the documents, Cast it to Proper Object and Enumerate it to List
<pre lang="csharp">
public override List<T> ListAll<T>(string table)
{
	return _DB.GetCollection<T>(GetTableName(table)).FindAllAs<T>().ToList();
}
</pre>

Similarly we add method implementation for AddNew(), Save(), and Where()

<pre lang="csharp">
public override void AddNew<T>(T record, string table)
{
	_DB.GetCollection(GetTableName(table)).Insert<T>(record);
}
public override void Save<T>(T record, string table)
{
	_DB.GetCollection(GetTableName(table)).Save<T>(record);
}
public override List<T> Where<T>(string query, string table)
{
	return _DB.GetCollection(GetTableName(table)).FindAs<T>(Query.Where(query)).ToList();
}
</pre>


Github : <a href="https://github.com/techphernalia/ClubManager/tree/e399865afb4ff249a73a5754cbadd3a0b0d97c9a" title="Browse this commit on Github" target="_blank" >https://github.com/techphernalia/ClubManager/tree/e399865afb4ff249a73a5754cbadd3a0b0d97c9a</a>

We have written our Data Layer but we are yet to configure our database. So we go ahead and setup our MongoDB database next.

Go to https://www.mongodb.org/downloads and download the version applicable for your operating system build.
Once downloaded extract the content to a suitable location say D:\_SVNWork\Source\MongoDB
Add two folders named data (to store database files) and log (to store log files) in the same directory (D:\_SVNWork\Source\MongoDB)
We are going to use a configuration file to configure our database file and name it mongo.conf and going to place it at the same location as our MongoDB binaries (D:\_SVNWork\Source\MongoDB\bin\mongo.conf) with following content

<pre>
dbpath=..\data
logpath=..\log\mongo-server.log
verbose=vvvvv
logappend=true
</pre>

In above file we are stating that our database files are going to be stored in data folder and logfile with name mongo-server.log in log folder. Log file is to be appended and logs are having a verbosity of vvvvv.

whenever required run this MongoDB instance using following command from command prompt and location D:\_SVNWork\Source\MongoDB\bin 

<pre>
mongod -f mongo.conf
</pre>

<pre class="cmd">
D:\_SVNWork\Source\MongoDB>dir
 Volume in drive D is Durgesh

 Directory of D:\_SVNWork\Source\MongoDB

02-05-2014  20:38    <DIR>          .
02-05-2014  20:38    <DIR>          ..
02-05-2014  20:37    <DIR>          bin
02-05-2014  20:43    <DIR>          data
04-08-2013  10:03            35,181 GNU-AGPL-3.0
02-05-2014  20:42    <DIR>          log
04-08-2013  10:03             1,359 README
04-08-2013  10:03            18,848 THIRD-PARTY-NOTICES
               3 File(s)         55,388 bytes
               5 Dir(s)  32,910,176,256 bytes free

D:\_SVNWork\Source\MongoDB>cd bin

D:\_SVNWork\Source\MongoDB\bin>dir
 Volume in drive D is Durgesh

 Directory of D:\_SVNWork\Source\MongoDB\bin

02-05-2014  20:37    <DIR>          .
02-05-2014  20:37    <DIR>          ..
31-10-2013  21:47        11,273,728 bsondump.exe
02-05-2014  20:41                78 mongo.conf
31-10-2013  20:02         6,379,520 mongo.exe
31-10-2013  20:13        11,329,536 mongod.exe
31-10-2013  20:13        91,720,704 mongod.pdb
31-10-2013  20:30        11,308,544 mongodump.exe
31-10-2013  20:49        11,276,288 mongoexport.exe
31-10-2013  21:37        11,289,600 mongofiles.exe
31-10-2013  20:58        11,294,208 mongoimport.exe
31-10-2013  21:27        11,272,704 mongooplog.exe
31-10-2013  21:56        11,284,480 mongoperf.exe
31-10-2013  20:39        11,299,328 mongorestore.exe
31-10-2013  20:20         8,848,896 mongos.exe
31-10-2013  20:20        70,765,568 mongos.pdb
31-10-2013  21:08        11,304,960 mongostat.exe
31-10-2013  21:17        11,276,288 mongotop.exe
              16 File(s)    301,924,430 bytes
               2 Dir(s)  32,910,176,256 bytes free

D:\_SVNWork\Source\MongoDB\bin>type mongo.conf
dbpath=..\data
logpath=..\log\mongo-server.log
verbose=vvvvv
logappend=true
D:\_SVNWork\Source\MongoDB\bin>mongod -f mongo.conf
Fri May 02 20:50:30.637
Fri May 02 20:50:30.639 warning: 32-bit servers don't have journaling enabled by default. Please use --journal if you want durability.
Fri May 02 20:50:30.640
all output going to: D:\_SVNWork\Source\MongoDB\bin\..\log\mongo-server.log
</pre>

When you do not require mongodb instance any more simply press Ctrl+C and it will stop normally.

Let us go back to frmMemberShipPlan and write functionality for save. In order to save we get MemberShipPlan object from form and then call AddNew or Save depending upon MemberShipPlanBeforeEdit. So we create FormToObject so that it can be used again if required.

<pre lang="csharp">
		private MemberShipPlan FormToObject()
		{
			return new MemberShipPlan
			{
				MemberShip = txtMemberShip.Text,
				Description = txtDescription.Text,
				AnnualFee = txtAnnualFee.Text.ToDouble(),
				MonthlyFee = txtMonthlyFee.Text.ToDouble(),
				QuarterlyFee = txtQuarterlyFee.Text.ToDouble(),
				HalfYearlyFee = txtHalfYearlyFee.Text.ToDouble(),
				IsActive = chkIsActive.Checked
			};
		}
</pre>

How do we generate id of MemberShipPlan? We are writing an application which can use any database and not all of them support auto_increment field e.g. MongoDB. So we are going to implement our own ID Generation mechanism. We will create an abstract method GetID which will accept a key and get an incremented value for key from configuration table. Implementation depends on the database used and if the same supports auto_increment field we will return null and DB will handle the same.

Core.Data.Context.cs
public abstract string GetID(string key);

Core.Data.Mongo.Mongo
public override string GetID(string key)
{
	return _DB.GetCollection(GetTableName(ConfigTable))
		.FindAndModify(Query.EQ("_id", key), null,
		Update.Inc("Value", 1), true, true).ModifiedDocument.GetElement("Value").Value.ToString();
}

So, now we have ID generation method as well, but where do we maintain key strings. Since key is dependent on Projects so we can not store it in any of our Core projects, but it is independent on database as well so we create a new project ClubManager.Data and store it in DBConstants class.

<pre lang="csharp">
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubManager.Data
{
	public class DBConstants
	{
		#region Config Keys
		public static string MemberShipPlanKey = "MemberShipPlan";
		#endregion

		#region Table Names
		public static string MemberShipPlanTable = "MemberShipPlan";
		#endregion
	}
}
</pre>

Let us now write the code to save MemberShipPlan

<pre lang="csharp">
		private void btnSave_Click(object sender, EventArgs e)
		{
			MemberShipPlan temp = FormToObject();
			if (MemberShipPlanBeforeEdit == null)
			{
				temp._id = Context.DB.GetID(DBConstants.MemberShipPlanKey);
				Context.DB.AddNew(temp, DBConstants.MemberShipPlanTable);
			}
			else
			{
				temp._id = MemberShipPlanBeforeEdit._id;
				Context.DB.Save(temp, DBConstants.MemberShipPlanTable);
				MemberShipPlanBeforeEdit = null;
				btnReset_Click(null, null);
			}
		}
</pre>

Adding and Editing is done but what about listing them. We write listing code in new Method BindGrid(). We remove any existing columns from DataGridView, Set DataSource, Hide _id column and add Edit button in each row.
<pre lang="csharp">
		private void BindGrid()
		{
			//Clear all the columns
			if (dgvMemberShipPlan.Columns.Count > 0)
				dgvMemberShipPlan.Columns.Clear();

			//Set Datasource
			dgvMemberShipPlan.DataSource = Context.DB.ListAll<frmMemberShipPlan>(DBConstants.MemberShipPlanTable);

			//Hide _id column
			dgvMemberShipPlan.Columns["_id"].Visible = false;

			//Add Edit button
			DataGridViewButtonColumn EditColumn = new DataGridViewButtonColumn();
			EditColumn.Text = "Edit";
			EditColumn.HeaderText = "Edit";
			EditColumn.UseColumnTextForButtonValue = true;
			dgvMemberShipPlan.Columns.Add(EditColumn);
		}
</pre>

We need to bind grid on form load, and after saving the data. So we call BindGrid() from frmMemberShipPlan() and in btnSave_Click()

How about Adding Edit Button functionality. For this we explore CellClick Event of DataGridView
<pre lang="csharp">
private void dgvMemberShipPlan_CellClick(object sender, DataGridViewCellEventArgs e)
{
	//Get the DataGridView object
	var senderGrid = sender as DataGridView;

	//Check if click is in valid cell
	if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn )
	{
		switch(senderGrid.Columns[e.ColumnIndex].HeaderText )
		{
			case"Edit":
				EditPlan((MemberShipPlan)senderGrid.Rows[e.RowIndex].DataBoundItem);
				break;
		}
	}
}
</pre>

How about listing all code from frmMemberShipPlan.cs
<pre lang="csharp">
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClubManager.Model;
using Core;
using Core.Data;
using ClubManager.Data;

namespace ClubManager
{
	public partial class frmMemberShipPlan : Form
	{
		private MemberShipPlan MemberShipPlanBeforeEdit = null;
		public frmMemberShipPlan()
		{
			InitializeComponent();
			BindGrid();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			MemberShipPlan temp = FormToObject();
			if (MemberShipPlanBeforeEdit == null)
			{
				temp._id = Context.DB.GetID(DBConstants.MemberShipPlanKey);
				Context.DB.AddNew(temp, DBConstants.MemberShipPlanTable);
			}
			else
			{
				temp._id = MemberShipPlanBeforeEdit._id;
				Context.DB.Save(temp, DBConstants.MemberShipPlanTable);
				MemberShipPlanBeforeEdit = null;
				btnReset_Click(null, null);
			}
			BindGrid();
		}

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
				txtMemberShip.Text =
					txtDescription.Text =
					txtMonthlyFee.Text =
					txtQuarterlyFee.Text =
					txtHalfYearlyFee.Text =
					txtAnnualFee.Text = "";
				chkIsActive.Checked = true;
			}
		}

		private MemberShipPlan FormToObject()
		{
			return new MemberShipPlan
			{
				MemberShip = txtMemberShip.Text,
				Description = txtDescription.Text,
				AnnualFee = txtAnnualFee.Text.ToDouble(),
				MonthlyFee = txtMonthlyFee.Text.ToDouble(),
				QuarterlyFee = txtQuarterlyFee.Text.ToDouble(),
				HalfYearlyFee = txtHalfYearlyFee.Text.ToDouble(),
				IsActive = chkIsActive.Checked
			};
		}

		private void BindGrid()
		{
			//Clear all the columns
			if (dgvMemberShipPlan.Columns.Count > 0)
				dgvMemberShipPlan.Columns.Clear();

			//Set Datasource
			dgvMemberShipPlan.DataSource = Context.DB.ListAll<MemberShipPlan>(DBConstants.MemberShipPlanTable);

			//Hide _id column
			dgvMemberShipPlan.Columns["_id"].Visible = false;

			//Add Edit button
			DataGridViewButtonColumn EditColumn = new DataGridViewButtonColumn();
			EditColumn.Text = "Edit";
			EditColumn.HeaderText = "Edit";
			EditColumn.UseColumnTextForButtonValue = true;
			dgvMemberShipPlan.Columns.Add(EditColumn);
		}

		public void NewPlan()
		{
			MemberShipPlanBeforeEdit = null;
			btnReset_Click(null, null);
			this.Show();
			this.Focus();
		}

		public void EditPlan(MemberShipPlan MemberShipPlan )
		{
			MemberShipPlanBeforeEdit = MemberShipPlan;
			btnReset_Click(null, null);
			this.Show();
			this.Focus();
		}

		private void dgvMemberShipPlan_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			//Get the DataGridView object
			var senderGrid = sender as DataGridView;

			//Check if click is in valid cell
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn )
			{
				switch(senderGrid.Columns[e.ColumnIndex].HeaderText )
				{
					case"Edit":
						EditPlan((MemberShipPlan)senderGrid.Rows[e.RowIndex].DataBoundItem);
						break;
				}
			}
		}
	}
}
</pre>

So we are all done. How do we run it? In order to run we need to Add Plan Manager in our Menu Bar, create an object of frmMemberShipPlan and call show on the same. But clicking the menu item again and again will result in multiple instances of frmMemberShipPlan, so we write our FormManger to handle all this.

FormManager will have static instances of all the forms.

<pre lang="csharp">
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubManager
{
	public class FormManager
	{
		public static frmMemberShipPlan MemberShipPlan = new frmMemberShipPlan();
		public static frmMain Main = new frmMain();

		static FormManager()
		{
			MemberShipPlan.MdiParent = Main;
		}
	}
}
</pre>

We also update our Program.cs to get Main form from our FormManager

<pre lang="csharp">
[STAThread]
static void Main()
{
	Application.EnableVisualStyles();
	Application.SetCompatibleTextRenderingDefault(false);
	Application.Run(FormManager.Main);
}
</pre>

How about adding menu now? Go to frmMain Designer View and Add Plan Manager under Membership Plan Menu item. In click event show and focus frmMemberShipPlan

<pre lang="csharp">
private void planManagerToolStripMenuItem_Click(object sender, EventArgs e)
{
	FormManager.MemberShipPlan.Show();
	FormManager.MemberShipPlan.Focus();
}
</pre>

But what if user closes the child form, our click event will fail. We need to prevent that so in FormClosing event simple cancel the event and Hide the form.
<pre lang="csharp">
		private void frmMemberShipPlan_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}
</pre> 

Before we run our application for the first time, please add the reference to project Core.Data.Mongo. You may ask why do we need to add this reference when my project is compiling perfectly and my application is not tightly bounded to any Database. Answer is Application requires this dll at runtime to perform its Data operations and you will have to copy this dll manually in that case. But if you add the reference then you need to not to do this manually.

Also some Decoration on our Main Form.
Set Text of form to "My Club", we will also make it configurable later on.
Set WindowState to "Maximized".

Go and run the application.

Create few Plans
Edit some plans
Close the application and try playing around with the controls.