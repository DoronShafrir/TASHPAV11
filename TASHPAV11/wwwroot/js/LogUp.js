var emailAddress = ""
function checkName(e, msgBack) {
    const reg = /^[a-zA-Z\ ]+$/;
    const msgName = document.getElementById(msgBack)
    if (!e.value.match(reg)) {
        msgName.style = "color:red"
        msgName.innerHTML = "Name should contain english letters only"
    }
    else {
        msgName.style = "color:green"
        msgName.innerHTML = "All Good";


    }
}
function checkPass(e) {
    const reg = /^[a-zA-Z0-9]+$/
    const msgName = document.getElementById("pmsg")
    if (!e.value.match(reg)) {
        msgName.style = "color:red"
        msgName.innerHTML = "Password should contain english letters or digits only"
    }
    else {
        msgName.style = "color:green"
        msgName.innerHTML = "All Good"
    }
}
function checkEmail(e) {
    emailAddress = e.value
    const reg = /^[a-zA-Z0-9\@.]+$/
    const msgName = document.getElementById("emsg")
    if (!e.value.match(reg)) {
        msgName.style = "color:red"
        msgName.innerHTML = "E-mail should contain english letters, '@','.' or digits only"
    }
    else {
        msgName.style = "color:green"
        msgName.innerHTML = "All Good"

    }
}
function checkTel(e) {
    const reg = /^[0-9\-]+$/
    const msgName = document.getElementById("tmsg")
    if (!e.value.match(reg)) {
        msgName.style = "color:red"
        msgName.innerHTML = "Phone number should contain digits only or '-' only"

    }
    else {
        msgName.style = "color:green"
        msgName.innerHTML = "All Good"

    }
}
function checkHobbies(e) {
    const reg = /^[a-zA-Z\ ]+$/
    const msgName = document.getElementById("hmsg")
    if (!e.value.match(reg)) {
        msgName.style = "color:red"
        msgName.innerHTML = "Hobby should contain english letters only";
    }
    else {
        msgName.style = "color:green"
        msgName.innerHTML = "All Good"
    }
}


function register1() {
    /***********Checking  if GENDER has been field*/
    let male = document.getElementById("Male");
    let female = document.getElementById("Female");
    let gmsg = document.getElementById("gmsg");
    if (!(male.checked || female.checked)) {
        S
        gmsg.style = "color:red"
        gmsg.innerHTML = "Male or Female  must be chosen";
    }
    else {
        gmsg.style = "color:green"
        gmsg.innerHTML = "All Good"
    }

    /***********Checking  Date of Birth*/
    let birthDate = document.getElementById("dName");
    let dmsg = document.getElementById("dmsg");
    if (birthDate.value == "") {
        dmsg.style = "color:red"
        dmsg.innerHTML = "Birth date must be filled";
    }
    else {
        dmsg.style = "color:green"
        dmsg.innerHTML = "All Good"
    }
    /************Checking  Email*/
    const reg = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/
    if (!emailAddress.match(reg)) {
        const msg = document.getElementById("emsg")
        msg.style = "color:red"
        msg.innerHTML = "Email Format is not correct"
    }
    /***********Checking  Confirmation*/
    let cName = document.getElementById("cName").checked
    if (!cName) {
        cmsg = document.getElementById("cmsg");
        cmsg.style = "color:red";
        cmsg.innerHTML = "One must confirm the above ae TRUE";
    }
    else {
        cmsg.style = "color:green"
        cmsg.innerHTML = "All Good"
    }
    /**********Check if all are "All Good" */
    let result = true;
    let messages = document.querySelectorAll(".messages");
    messages.forEach((message) => {
        if (message.innerHTML != "All Good") { result = false }
    });
    return result;

}

function clearConfirm() {
    let confirm = document.getElementById("cmsg");
    confirm.innerHTML = null;
}


function reset1() {
    let messages = document.querySelectorAll(".messages");
    messages.forEach((message) => {
        message.innerHTML = null;
    });
}

//function register1() {
//    alert("I am crazy");
//}