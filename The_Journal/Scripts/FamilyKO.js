


var AddChildVM = function AddChild(ChildFirstName, ChildLastName, ChildDOB, ChildKnownName, ChildGender, ChildAge, ChildStartDate, ChildEndDate, ChildSEN, employeeID, ChildAllergy, roomID)
{
    var child = this;

    child.ChildFirstName = ChildFirstName;
    child.ChildLastName = ChildLastName;
    child.ChildKnownName = ChildKnownName;
    child.ChildDOB = ChildDOB;
    child.Gender = ChildGender;
    child.ChildAge = ChildAge;
    child.ChildStartDate = ChildStartDate;
    child.ChildEndDate = ChildEndDate;
    child.ChildSEN = ChildSEN;
    child.EmployeeID = employeeID;
    child.ChildAllergy = ChildAllergy;
    child.RoomID = roomID;
   
}
var AddCarerVM = function AddCarer(CFirstName, CLastName, CDOB, CEmail, CHomeNum, CWorkNum, CMobileNum, CAddress, CPostCode)
{
    var carer = this;
    carer.CFirstName = CFirstName;
    carer.CLastName = CLastName;
    carer.CDOB = CDOB;
    carer.CEmail = CEmail;
    carer.CHomeNum = CHomeNum;
    carer.CWorkNum = CWorkNum;
    carer.CMobileNum = CMobileNum;
    carer.CAddress = CAddress;
    carer.CPostCode = CPostCode;
}

var AddECVM = function AddEmergencyContact(ECFirstName,ECLastName,ECMobileNum,ECRelationship)
{
    var eContact=this;
    eContact.ECFirstName=ECFirstName;
    eContact.ECLastName= ECLastName;
    eContact.ECMobileNum= ECMobileNum;
    eContact.ECRelationship = ECRelationship;
}

function AddFamilyViewModel()
{
    var family = this;

    family.Children = ko.observableArray();

    family.Carers = ko.observableArray();
    
    family.EContacts = ko.observableArray();
    

    ///New Child Props
    family.NewChildFirstName = ko.observable();
    family.NewChildLastName = ko.observable();
    family.NewChildDOB = ko.observable();
    family.NewChildKnownName = ko.observable();
    family.NewChildGender = ko.observable();
    family.NewChildGenderOptions = ko.observableArray([{ Gender: "Male" }, { Gender: "Female" }]);
    family.NewChildAge = ko.observable();
    family.NewChildStartDate = ko.observable();
    family.NewChildEndDate = ko.observable();
    family.NewChildSEN = ko.observable();
    family.NewChildKeyWorkerID = ko.observable();
    family.NewChildKeyWorkerOptions = ko.observableArray();
    family.NewChildAllergy = ko.observable();
    family.NewChildRoomID = ko.observable();
    family.NewChildRoomOptions = ko.observableArray();
    

    //load Keyworkers
    $.ajax({
        url: "/Employees/GetData",
        type: "Get",
        contentType: "application/json",
        async: false,
        success: function (data) {
            
            family.NewChildKeyWorkerOptions(data)
        }
    });


    //load Rooms
    $.ajax({
        url: "/Rooms/GetData",
        type: "Get",
        contentType: "application/json",
        async: false,
        success: function (data) {
            family.NewChildRoomOptions(data)
        }
    });

    ///Add and Remove Child
    family.addChild = function () {

        //if (family.NewChildFirstName.isValid() && family.NewChildLastName.isValid() && NewChildDOB.isValid() && family.NewChildKnownName.isValid() && family.NewChildGender.isValid() && family.NewChildAge.isValid() && family.NewChildStartDate.isValid() && family.NewChildEndDate.isValid() && family.NewChildSEN.isValid() && family.NewChildRoom.isValid() && family.NewChildAllergy.isValid() && family.NewChildKeyWorker.isValid())
        //{

            family.Children.push(new AddChildVM(family.NewChildFirstName(), family.NewChildLastName(), family.NewChildDOB(), family.NewChildKnownName(), family.NewChildGender(), family.NewChildAge(), family.NewChildStartDate(), family.NewChildEndDate(), family.NewChildSEN(), family.NewChildKeyWorkerID(), family.NewChildAllergy(), family.NewChildRoomID()));

            family.NewChildFirstName("");
            family.NewChildLastName("");
            family.NewChildDOB("");
            family.NewChildKnownName("");
            family.NewChildGender("");
            family.NewChildAge("");
            family.NewChildStartDate("");
            family.NewChildEndDate("");
            family.NewChildSEN("");
            family.NewChildKeyWorkerID("");
            family.NewChildAllergy("");
            family.NewChildRoomID("");
            return false;
       // }

    }
    family.removeChild = function (Child) { family.Children.remove(Child) }


    ///New Carer props
    family.NewCarerFirstName = ko.observable().extend({
        required: true,
        minLength: 3,
        pattern: {
            message: 'This field must contain only letters',
            params: '^[A-Za-z ]+$'
        }
    });

    family.NewCarerLastName = ko.observable().extend({
        required: true,
        minLength: 3,
        pattern: {
            message: 'This field must contain only letters',
            params: '^[A-Za-z ]+$'
        }
    });

    family.NewCarerDOB = ko.observable().extend({ required: true });

    family.NewCarerHomeNum = ko.observable().extend({
        required: true,
        minLength: 7,
        maxLength: 7,
        pattern: {
            message: 'This field must contain only numbers',
            params: '^[0-9 ]*$'
        }
    });

    family.NewCarerMobileNum = ko.observable().extend({
        required: true,
        minLength: 10,
        maxLength: 10,
        pattern: {
            message: 'This field must contain only numbers',
            params: '^[0-9 ]*$'
        }
    });

    family.NewCarerWorkNum = ko.observable().extend({
        required: true,
        minLength: 7,
        maxLength: 7,
        pattern: {
            message: 'This field must contain only numbers',
            params: '^[0-9 ]*$'
        }
    });

    family.NewCarerAddress = ko.observable().extend({
        required: true,
        pattern: {
            message: 'This field must not contain any other character',
            params: '[A-Za-z0-9\'\.\-\s\,]'
        }
    });


    family.NewCarerPostCode = ko.observable().extend({
        required: true,
        //pattern: {
        //    message: 'This field must be in Postcode Pattern Ex: A00 0AA ',
        //    params: '/[A-Z]{1,2}[0-9][0-9A-Z]?\s?[0-9][A-Z]{2}/g'
        //}
    });

    family.NewCarerEmail = ko.observable().extend({ email: true, required: true });


    ///Add and Remove Carer
    family.addCarer = function () {

        if (family.NewCarerFirstName.isValid() && family.NewCarerLastName.isValid()  && family.NewCarerEmail.isValid() && family.NewCarerHomeNum.isValid() && family.NewCarerMobileNum.isValid() && family.NewCarerWorkNum.isValid() && family.NewCarerAddress.isValid() && family.NewCarerPostCode.isValid())
        {
            family.Carers.push(new AddCarerVM(family.NewCarerFirstName(), family.NewCarerLastName(), family.NewCarerDOB(), family.NewCarerEmail(), family.NewCarerHomeNum(), family.NewCarerMobileNum(), family.NewCarerWorkNum(), family.NewCarerAddress(), family.NewCarerPostCode()));

            family.NewCarerFirstName("");
            family.NewCarerFirstName.clearError();
            family.NewCarerLastName("");
            family.NewCarerLastName.clearError();
            family.NewCarerDOB("");
            family.NewCarerDOB.clearError();
            family.NewCarerEmail("");
            family.NewCarerEmail.clearError();
            family.NewCarerHomeNum("");
            family.NewCarerHomeNum.clearError();
            family.NewCarerMobileNum("");
            family.NewCarerMobileNum.clearError();
            family.NewCarerWorkNum("");
            family.NewCarerWorkNum.clearError();
            family.NewCarerAddress("");
            family.NewCarerAddress.clearError();
            family.NewCarerPostCode("");
            family.NewCarerPostCode.clearError();
            return false;
        }

    }
    family.removeCarer = function (Carer) { family.Carers.remove(Carer) }


    ///New Emergency Contacts Props

    family.NewECFirstName = ko.observable().extend({
        required: true,
        minLength: 3,
        pattern: {
            message: 'This field must contain only letters',
            params: '^[A-Za-z ]+$'
        }
    });

    family.NewECLastName = ko.observable().extend({
        required: true,
        minLength: 3,
        pattern: {
            message: 'This field must contain only letters',
            params: '^[A-Za-z ]+$'
        }
    });

    family.NewECMobileNum = ko.observable().extend({
        required: true,
        minLength: 10,
        maxLength: 10,
        pattern: {
            message: 'This field must contain only numbers',
            params: '^[0-9 ]*$'
        }
    });

    family.NewECRelationship = ko.observable().extend({
        required: true,
        minLength: 3,
        pattern: {
            message: 'This field must contain only letters',
            params: '^[A-Za-z ]+$'
        }
    });

    ///Add and Remove Emergency Contact
    family.addEC = function () {
        if (family.NewECFirstName.isValid() && family.NewECMobileNum.isValid() && family.NewECLastName.isValid() && family.NewECRelationship.isValid())
        {
            family.EContacts.push(new AddECVM(family.NewECFirstName(), family.NewECLastName(), family.NewECMobileNum(), family.NewECRelationship()));

            family.NewECFirstName("");
            family.NewECFirstName.clearError();
            family.NewECLastName("");
            family.NewECLastName.clearError();
            family.NewECMobileNum("");
            family.NewECMobileNum.clearError();
            family.NewECRelationship("");
            family.NewECRelationship.clearError();
        }
        return false;
    }
    family.removeEContact = function (EContact) { family.EContacts.remove(EContact) }

    ///Converting Data to JSON

    family.RawData = ko.computed(function () {
        var data = ko.toJS(family);

        delete data.RawData;

        delete data.ChildFirstName;
        delete data.ChildLastName;
        delete data.ChildDOB;
        delete data.ChildKnownName;
        delete data.ChildGender;
        delete data.ChildAge;
        delete data.ChildStartDate;
        delete data.ChildEndDate;
        delete data.ChildSEN;
        delete data.EmployeeID;
        delete data.ChildAllergy;
        delete data.RoomID;

        delete data.NewCarerFirstName;
        delete data.NewCarerLastName;
        delete data.NewCarerDOB;
        delete data.NewCarerHomeNum;
        delete data.NewCarerMobileNum;
        delete data.NewCarerWorkNum;
        delete data.NewCarerAddress;
        delete data.NewCarerPostCode;
        delete data.NewCarerEmail;

        delete data.NewECFirstName;
        delete data.NewECLastName;
        delete data.NewECMobileNum;
        delete data.NewECRelationship;

        return JSON.stringify(data);
    });

    family.Done = function () {
        $.ajax({
            url: "/Families/Save",
            type: "post",
            data: family.RawData(),
            datatype: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                alert(result);
            }
        });
    }


}
ko.applyBindings(new AddFamilyViewModel());