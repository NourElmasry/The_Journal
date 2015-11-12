//var viewModel = {

//    ContactID: '',
//    CFirstName: 'Nour',
//    CLastName: '',
//    CDOB: '',
//    CHomeNum: '',
//    CWorkNum: '',
//    CMobileNum: '',
//    CAddress: '',
//    CPostCode: '',
//    EmergencyContactID: '',
//    EmFirstName: '',
//    EmLastName: '',
//    EmMobileNum: '',
//    EmRelationship: '',
//    addCarer: '',
//    addEC:''
//};

var AddCarerVM= function AddCarer(CFirstName, CLastName, CDOB, CHomeNum, CWorkNum, CMobileNum, CAddress, CPostCode)
{
    var carer = this;
    carer.CFirstName = CFirstName;
    carer.CLastName = CLastName;
    carer.CDOB = CDOB;
    carer.CHomeNum = CHomeNum;
    carer.CWorkNum = CWorkNum;
    carer.CMobileNum = CMobileNum;
    carer.CAddress = CAddress;
    carer.CPostCode = CPostCode;
   // carer.addCarer = " ";
    //carer.addCarer = function () {
    //    carer.Carers.push(new AddCarer("","","","","","","",""));
    //}

}

var AddECVM = function AddEmergencyContact(EmFirstName,EmLastName,EmMobileNum,EmRelationship)
{
    var eContact=this;
    eContact.EmFirstName=EmFirstName;
    eContact.EmLastName= EmLastName;
    eContact.EmMobileNum= EmMobileNum;
    eContact.EmRelationship = EmRelationship;
    //eContact.addEC = " ";
    //eContact.addEC = function () {
    //    eContact.EmConatcts.push(new AddEmergencyContact("","","",""));
    //}
   
}

function AddFamilyViewModel()
{
    var family = this;

    family.Carers = ko.observableArray();
    
    family.EmContacts = ko.observableArray([new AddECVM("c", "d", "2", "d")]);
    
    family.addCarer= function () {
        family.Carers.push(new AddCarerVM(family.NewCarerFirstName(), family.NewCarerLastName(), " ", " ", " ", " ", " ", " "));

        family.NewCarerFirstName("");
        family.NewCarerLastName("");

        return false;
    }

    family.addEC = function () {
        family.EmContacts.push(new AddECVM("", "", "", ""));

        return false;
    }


    family.NewCarerFirstName = ko.observable();
    family.NewCarerLastName = ko.observable();

    family.RawData = ko.computed(function () {
        var data = ko.toJS(family);
        delete data.RawData;
        delete data.NewCarerFirstName;
        delete data.NewCarerLastName;
        return JSON.stringify(data);
    });
}
ko.applyBindings(new AddFamilyViewModel());