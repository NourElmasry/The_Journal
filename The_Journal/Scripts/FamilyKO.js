var AddChildVM = function AddChild(ChildFirstName, ChildLastName, ChildDOB, ChildKnownName, ChildGender, ChildAge, ChildStartDate, ChildEndDate, ChildSEN, ChildKeyWorker,ChildAllergy, ChildRoom)
{
    var child = this;

    child.ChildFirstName = ChildFirstName;
    child.ChildLastName = ChildLastName;
    child.ChildDOB = ChildDOB;
    child.ChildKnownName = ChildKnownName;
    child.ChildGender = ChildGender;
    child.ChildAge = ChildAge;
    child.ChildStartDate = ChildStartDate;
    child.ChildEndDate = ChildEndDate;
    child.ChildSEN = ChildSEN;
    child.ChildKeyWorker = ChildKeyWorker;
    child.ChildAllergy = ChildAllergy;
    child.ChildRoom = ChildRoom;
   
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

    family.Carers = ko.observableArray();
    
    family.EContacts = ko.observableArray();
    
    famil.Children = ko.observableArray();

    family.addCarer = function () {

        if (family.NewCarerFirstName.isValid() && family.NewCarerLastName.isValid() && familyNewCarerDOB.isValid() && family.NewCarerEmail.isValid() && family.NewCarerHomeNum.isValid() && family.NewCarerMobileNum.isValid() && family.NewCarerWorkNum.isValid() && family.NewCarerAddress.isValid() && family.NewCarerPostCode.isValid())
        {
            family.Carers.push(new AddCarerVM(family.NewCarerFirstName(), family.NewCarerLastName(), family.NewCarerDOB(), family.NewCarerEmail(), family.NewCarerHomeNum(), family.NewCarerMobileNum(), family.NewCarerWorkNum(), family.NewCarerAddress(), family.NewCarerPostCode()));

            family.NewCarerFirstName("");
            family.NewCarerLastName("");
            family.NewCarerDOB("");
            family.NewCarerEmail("");
            family.NewCarerHomeNum("");
            family.NewCarerMobileNum("");
            family.NewCarerWorkNum("");
            family.NewCarerAddress("");
            family.NewCarerPostCode("");
            return false;
        }

    }


    family.addChild = function () {

        if (family.NewCarerFirstName.isValid() && family.NewCarerLastName.isValid() && familyNewCarerDOB.isValid() && family.NewCarerEmail.isValid() && family.NewCarerHomeNum.isValid() && family.NewCarerMobileNum.isValid() && family.NewCarerWorkNum.isValid() && family.NewCarerAddress.isValid() && family.NewCarerPostCode.isValid()) {
            family.Carers.push(new AddCarerVM(family.NewCarerFirstName(), family.NewCarerLastName(), family.NewCarerDOB(), family.NewCarerEmail(), family.NewCarerHomeNum(), family.NewCarerMobileNum(), family.NewCarerWorkNum(), family.NewCarerAddress(), family.NewCarerPostCode()));

            child.ChildFirstName("");
            child.ChildLastName("");
            child.ChildDOB("");
            child.ChildKnownName("");
            child.ChildGender("");
            child.ChildAge("");
            child.ChildStartDate("");
            child.ChildEndDate("");
            child.ChildSEN("");
            child.ChildKeyWorker("");
            child.ChildAllergy("");
            child.ChildRoom("");
            return false;
        }

    }


    family.removeCarer = function(Carer) { family.Carers.remove(Carer) }
   
    family.removeChild = function (Child) { family.Children.remove(Child) }

    family.addEC = function () {
        if (family.NewECFirstName.isValid() && family.NewECMobileNum.isValid() && family.NewECLastName.isValid() && family.NewECRelationship.isValid())
        {
            family.EContacts.push(new AddECVM(family.NewECFirstName(), family.NewECLastName(), family.NewECMobileNum(), family.NewECRelationship()));

            family.NewECFirstName("");
            family.NewECLastName("");
            family.NewECMobileNum("");
            family.NewECRelationship("");
        }
        return false;
    }

    family.removeEContact = function (EContact) { family.EContacts.remove(EContact) }

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

    family.NewCarerDOB = ko.observable().extend({required: true});

    family.NewCarerHomeNum = ko.observable().extend({
        required: true,
        minLength: 7,
        maxLength:7,
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
        pattern: {
            message: 'This field must be in Postcode Pattern Ex: A00 0AA ',
            params: '/[A-Z]{1,2}[0-9][0-9A-Z]?\s?[0-9][A-Z]{2}/g'
        }
    });

    family.NewCarerEmail = ko.observable().extend({ email: true, required: true });

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

    family.RawData = ko.computed(function () {
        var data = ko.toJS(family);



        


        delete data.RawData;

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