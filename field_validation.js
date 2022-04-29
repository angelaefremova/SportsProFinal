const $ = id => document.getElementById(id);
// We decided not to lock/disable the submit button and let two validation methods
// work together

const name_pattern = /^[A-Z][a-z]*[\.]*([\s][A-Z][a-z]*[\.]*)*$/;
const mail_pattern = /^[A-Za-z0-9]*([_\.\-]?[A-Za-z0-9]+)*@[A-Za-z0-9]+([\.\-]?[A-Za-z0-9]+)*(\.{1})([A-Za-z]{2,})$/;
const postcode_pattern = /^([A-Za-z]{1}(\d{1})[A-Za-z]{1}){1}(\s)?((\d{1})[A-Za-z]{1}(\d{1})){1}$/;
const phone_pattern_1 = /^(\d{3})(\-\d{3})(\-\d{4})$/;
const phone_pattern_2 = /^\d{10}$/;
const phone_pattern_3 = /^(\({1})(\d{3})(\){1})\s(\d{3})(-\d{4})$/;

const special_chars = /[\!\@\#\$\%\^\&\*\(\)\+\\\/]/;
const special_chars_email = /[\!\#\$\%\^\&\*\(\) \+\s]/;

// Fetch input fields
const first_name = $("first_name");
const last_name = $("last_name");
const post_code = $("post_code");
const country = $("country")
const email = $("email");
const phone = $("phone");



const fn_alert = $("fn_alert");
const ln_alert = $("ln_alert");
const postcode_alert = $("postcode_alert");
const country_alert = $("country_alert");
const mail_alert = $("mail_alert");
const phone_alert = $("phone_alert");


if (first_name != null) {
  first_name.addEventListener("input", () => {
    if (name_pattern.test(first_name.value)) {
      ValidDisplay(fn_alert);
    } else {
      InvalidDisplay(fn_alert, "name", first_name.value);
    }
  })
}

if (last_name != null) {
  last_name.addEventListener("input", () => {
    if (name_pattern.test(last_name.value)) {
      ValidDisplay(ln_alert);
    } else {
      InvalidDisplay(ln_alert, "name", last_name.value);
    }
  })
}

if (post_code != null) {
  post_code.addEventListener("input", () => {
    if (postcode_pattern.test(post_code.value)) {
      ValidDisplay(postcode_alert);
    }
    else {
      InvalidDisplay(postcode_alert, "postcode", post_code.value);
    }
  })
}

if (country != null) {
  country.addEventListener("click", () => {
    if (country.value == 0) {
      InvalidDisplay(country_alert, "country", country.value)
    } else ValidDisplay(country_alert);
  })
}

if (email != null) {
  email.addEventListener("input", () => {
    if (country != null) {
      if (country.value == 0) {
        InvalidDisplay(country_alert, "country", country.value)
      } else ValidDisplay(country_alert);
    }
    if (mail_pattern.test(email.value)) {
      ValidDisplay(email_alert);
    }
    else {
      InvalidDisplay(email_alert, "mail", email.value);
    }
  })
}

if (phone != null) {
  phone.addEventListener("input", () => {
    if (!phone_pattern_1.test(phone.value) && !phone_pattern_2.test(phone.value) && !phone_pattern_3.test(phone.value)) {
      InvalidDisplay(phone_alert, "phone", phone.value);
    } else {
      ValidDisplay(phone_alert);
    }
  })
}

function ValidDisplay(item) {
  item.style.display = "none";
  item.style.display = "block";
  item.style.color = "rgb(58, 201, 58)";
  item.style.transitionDuration = "1s ease-out";
  item.innerHTML = "Looks good!";
  item.hide = false;
}
// Value displayed when user's input is invalid.
function InvalidDisplay(item, type, usrInput) {
  item.style.display = "none";
  item.style.display = "block";
  item.style.color = "red";
  item.style.transitionDuration = "1s ease-in";
  item.hide = false;
  item.innerHTML = "Invalid input.";

  try {
    if (type == "name" && /[0-9]/.test(usrInput)) item.innerHTML += "<br>A valid name must NOT contain any numbers."

    if (type == "name" && special_chars.test(usrInput)) item.innerHTML += "<br>A valid name must NOT contain any special character such as !@#$%^&*. Unless it's Elon's son name."

    if (type == "postcode" && !postcode_pattern.test(usrInput)) item.innerHTML += "<br>Please enter a Canada valid post code. E.g. M1A 1A1 or K1G1H3 (without space), etc."

    if (type == "phone" && !phone_pattern_1.test(usrInput) && !phone_pattern_2.test(usrInput)) item.innerHTML += " Please enter a valid pattern of phone number<br>For example: 416-100-3000 or 4161003000."

    if (type == "mail" && special_chars_email.text(usrInput)) item.innerHTML += "<br>Input must NOT contain any special characters like !#$%^&*()"

    if ((type == "country")) item.innerHTML += " \"Country\" can not be left empty.<br>Please select the country name where you currently reside."
  } catch (err) {
    usrAlert.innerHTML += err;
  }
}