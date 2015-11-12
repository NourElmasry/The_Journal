var AddCarerVM= function AddCarer(CFirstName, CLastName, CDOB, CEmail, CHomeNum, CWorkNum, CMobileNum, CAddress, CPostCode)
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
    
    family.addCarer= function () {
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

    family.removeCarer = function(Carer) { family.Carers.remove(Carer) }
   


    family.addEC = function () {
        family.EContacts.push(new AddECVM(family.NewECFirstName(), family.NewECLastName(), family.NewECMobileNum(), family.NewECRelationship()));

        family.NewECFirstName("");
        family.NewECLastName("");
        family.NewECMobileNum("");
        family.NewECRelationship("");
        return false;
    }

    family.removeEContact = function (EContact) { family.EContacts.remove(EContact) }

    family.NewCarerFirstName = ko.observable();
    family.NewCarerLastName = ko.observable();
    family.NewCarerDOB = ko.observable();
    family.NewCarerHomeNum = ko.observable();
    family.NewCarerMobileNum = ko.observable();
    family.NewCarerWorkNum = ko.observable();
    family.NewCarerAddress = ko.observable();
    family.NewCarerPostCode = ko.observable();
    family.NewCarerEmail = ko.observable();

    family.NewECFirstName = ko.observable();
    family.NewECLastName = ko.observable();
    family.NewECMobileNum = ko.observable();
    family.NewECRelationship = ko.observable();

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
}
ko.applyBindings(new AddFamilyViewModel());