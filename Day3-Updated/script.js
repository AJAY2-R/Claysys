function showSlide() {
    const slides = document.querySelectorAll(".slide");
    slides.forEach((slide) => {
        slide.style.display = "none";
    });

    currentSlide = (currentSlide + 1) % slides.length;

    slides[currentSlide].style.display = "block";
    setTimeout(showSlide, 3000);
}

var statecity = {
    "Kerala": ["Kochi", "Aluva", "Kottaym"],
    "TamilNadu": ["Chennai", "Coimbatore", "Madura"],
    "Karnadaka": ["Bengaluru", "Mysuru", "Mangaluru"]
}

function updateCity() {
    var state = document.getElementById('state').value;
    var city = document.getElementById('city');
    city.innerHTML = "";

    for (var i = 0; i < statecity[state].length; i++) {
        var opt = document.createElement('option');
        opt.value = statecity[state][i];
        opt.textContent = statecity[state][i];
        city.appendChild(opt);
    }
}

function validateFname(fname) {
    let er = document.getElementById('error-fname');
    if (fname.value.trim() === '') {
        er.textContent = "Please enter the first name"
        fname.style.border = "1px solid red "
        return false
    }
    if(fname.value.length < 2) {
        er.textContent = "Name must be at least 2 characters";
        fname.style.border = "1px solid red "
        return false;
      }
    if(!/^[a-zA-Z]+$/.test(fname.value)) {
        er.textContent = "Name must contain only letters"; 
        fname.style.border = "1px solid red "
        return false;
      }
      
        er.textContent = ""
        fname.style.border = "1px solid gray "
        return true
}
function validateLname(lname) {
    let er = document.getElementById('error-lname');
    if (lname.value.trim() === '') {
        er.textContent = "Please enter the last name"
        document.getElementById('lname').style.border = "1px solid red "
        return false
    }
    if(lname.value.length < 2) {
        er.textContent = "Name must be at least 2 characters";
        fname.style.border = "1px solid red "
        return false;
      }
    if(!/^[a-zA-Z]+$/.test(lname.value)) {
        er.textContent = "Name must contain only letters"; 
        fname.style.border = "1px solid red "
        return false;
      }

        er.textContent = ""
        document.getElementById('lname').style.border = "1px solid gray "
        return true

}
function disableFutureDates(dateElement) {
    // Get today's date
    var today = new Date(); 
    var dd = today.getDate();
    var mm = today.getMonth() + 1;
    var yyyy = today.getFullYear();
    if(dd < 10) {
      dd = '0' + dd;
    }
    if(mm < 10) {
      mm = '0' + mm; 
    }
    today = yyyy + '-' + mm + '-' + dd;
    dateElement.max = today;
  }

//calculate the age 
function calcAge(dob) {
    let er = document.getElementById('error-date');
    if (dob.value == '') {
        er.textContent = "Please select the date"
       dob.style.border = "1px solid red "
        return false
    }
    else {
        var dob = new Date(dob.value);
        var today = new Date();
        var age = today.getFullYear() - dob.getFullYear();
        if (
            today.getMonth() < dob.getMonth() ||
            (today.getMonth() === dob.getMonth() && today.getDate() < dob.getDate())
        ) {
            age--;
        }
        if (age<=18){
           er.textContent = "You must be at least 18 years old"
           dob.style.border = "1px solid red "
            return false
        }
         else{
        document.getElementById('age').innerHTML = age+" Years old";
        dob.style.border = "1px solid gray "
        er.textContent = ''
        return true
         }
    }
}
function validateGender() {
    var male = document.getElementById("male");
    var female = document.getElementById("female");
    var other = document.getElementById("other");
    let er = document.getElementById('error-gender');
    if (!male.checked && !female.checked && !other.checked) {
        er.textContent = "Please select the gender"
        return false
    }
    else
    {
        er.textContent = ""
        return true
    }
}
function validatePhone(phone) {
    var frmt = /^[0-9]{10}$/;
    var er = document.getElementById('error-phone');
    if (!frmt.test(phone.value)) {
        er.textContent = 'Please enter a valid phone number';
        document.getElementById('phone').style.border = "1px solid red "
        return false
    } else {
        er.textContent = '';
        document.getElementById('phone').style.border = "1px solid gray"
        return true
    }
}
function validateEmail(email) {
var frmt = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
var er = document.getElementById('error-email');
if (!frmt.test(email.value)) {
    er.textContent = 'Please enter a valid email address';
    document.getElementById('email').style.border = "1px solid red ";
    return false;
} else {
    er.textContent = '';
    document.getElementById('email').style.border = "1px solid gray ";
    return true;
}
}


function validateStateCity() {
var state = document.getElementById('state').value;
var city = document.getElementById('city').value;
var errorState = document.getElementById('error-state');

if (state === 'Select a state' || city === '') {
    errorState.textContent = 'Please select a state and city';
    return false; 
} else {
    errorState.textContent = '';
    return true; 
}
}

function validateAddress(address) {
    let er = document.getElementById('error-address');
    if (address.value.trim() === '') {
        er.textContent = "Please write the address"
        document.getElementById('address').style.border = "1px solid red "
        return false
    }
    else {
        er.textContent = ""
        document.getElementById('address').style.border = "1px solid gray "
        return true
    }
}
function validateUsername(username) {
    let er = document.getElementById('error-username');
    if(username.value.trim().length < 3) {
        er.textContent = "Username must be at least 3 characters";
        return false;
      }
    if (username.value.trim() === '') {
        er.textContent = "Please Enter the Username"
        username.style.border = "1px solid red "
        return false
    }
    else {
        er.textContent = ""
        username.style.border = "1px solid gray "
        return true
    }
}
function validatePass(pass) {
var password = pass.value;
var er = document.getElementById("error-password");
var strengthBar = document.getElementById('password-strength');
var len = password.length >= 8;
var spchar = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/.test(password);
var capital = /[A-Z]/.test(password);
var errorMsg = "";
var strength = 0;

if (len) {
    strength += 1;
}
if (spchar) {
    strength += 1;
}
if (capital) {
    strength += 1;
}

switch (strength) {
    case 0:
        strengthBar.innerHTML = "<span class='weak'></span>";
        break;
    case 1:
        strengthBar.innerHTML = "<span class='better'></span>";
        break;
    case 2:
        strengthBar.innerHTML = "<span class='medium'></span>";
        break;
    case 3:
        strengthBar.innerHTML = "<span class='strong'></span>";
        break;
    }

    if (!len) {
        errorMsg += "Password must be at least 8 characters long  ";
    }
    if (!spchar) {
        errorMsg += "Password must include special characters \n";
    }
    if (!capital) {
        errorMsg += "Password must include capital letters  \n";
    }

    if (errorMsg) {
        er.textContent = errorMsg;
        pass.style.border = "1px solid red";
        return false
    } else {
        er.textContent = "";
        pass.style.border = "1px solid gray";
        return true
    }
}

function validatePass(pass) {
    var password = pass.value;
    var er = document.getElementById("error-password");
    var len = password.length >= 8;
    var spchar = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/.test(password);
    var capital = /[A-Z]/.test(password);
    var errorMsg = "";
        if (!len || !spchar || !capital) {
            errorMsg += "Invalid password ";
        }
        
    
        if (errorMsg) {
            er.textContent = errorMsg;
            pass.style.border = "1px solid red";
            return false
        } else {
            er.textContent = "";
            pass.style.border = "1px solid gray";
            return true
        }
    }

function validateCpass(cpasswordField) {
var password = document.getElementById("password").value;
var cpassword = cpasswordField.value;
var er = document.getElementById("error-cpassword");
if (password ===""){
    er.textContent = "Password field can't leave empty";
    cpasswordField.style.border = "1px solid red";
    return false
}
else if (password !== cpassword) {
    er.textContent = "Passwords do not match";
    cpasswordField.style.border = "1px solid red";
    return false
} else {
    er.textContent = "";
    cpasswordField.style.border = "1px solid gray";
    return true
}
}

function validateSignupForm() {
var isvalid = true; 
isvalid = validateFname(fname) && isvalid;
isvalid = validateLname(document.getElementById('lname')) && isvalid;
isvalid = calcAge(document.getElementById('dob')) && isvalid;
isvalid = validateGender() && isvalid;
isvalid = validatePhone(document.getElementById('phone')) && isvalid;
isvalid = validateEmail(document.getElementById('email')) && isvalid;
isvalid = validateStateCity() && isvalid;
isvalid = validateAddress(document.getElementById('address')) && isvalid;
isvalid = validateUsername(username) && isvalid;
isvalid = validatePass(document.getElementById('password')) && isvalid;
isvalid = validateCpass(document.getElementById('cpassword')) && isvalid;

return isvalid;
}
function validateLoginForm() {
    var isvalid = true; 
    isvalid = validateEmail(document.getElementById('email')) && isvalid;
    isvalid = validatePass(document.getElementById('password')) && isvalid;
    return isvalid;
}


function validateMessage(message) {
    let er = document.getElementById('error-message');
    if (message.value.trim() === '') {
        er.textContent = "Please write a message"
        document.getElementById('message').style.border = "1px solid red "
        return false
    }
    else if(message.value.length >20){
        er.textContent = "Please write fewer words";
        document.getElementById('message').style.border = "1px solid red "
        return false
    }
    else {
        er.textContent = ""
        document.getElementById('message').style.border = "1px solid gray "
        return true
    }
}
function validateContactForm() {
var isvalid = true; 
isvalid = validateFname(document.getElementById('fname')) && isvalid;
isvalid = validateLname(document.getElementById('lname')) && isvalid;
isvalid = validatePhone(document.getElementById('phone')) && isvalid;
isvalid = validateEmail(document.getElementById('email')) && isvalid;
isvalid = validateMessage(document.getElementById('message')) && isvalid;
return isvalid;
}
