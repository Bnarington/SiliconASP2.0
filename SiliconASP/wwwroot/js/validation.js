//document.addEventListener('DOMContentLoaded', function () {
//    const signInForm = document.querySelector('.signin-form');
//    const signUpForm = document.querySelector('.signup-form');
//    const email = document.getElementById('email');
//    const password = document.getElementById('password');
//    const firstName = document.getElementById('firstname');
//    const lastName = document.getElementById('lastname');
//    const confPassword = document.getElementById('conf-password');

//    if (signInForm) {
//        email.addEventListener('change', signInValidation);
//        password.addEventListener('change', signInValidation);
//    }

//    if (signUpForm) {
//        firstName.addEventListener('change', signUpValidation);
//        lastName.addEventListener('change', signUpValidation);
//        email.addEventListener('change', signUpValidation);
//        password.addEventListener('change', signUpValidation);
//        confPassword.addEventListener('change', signUpValidation);
//    }
//});

//function signInValidation() {
//    const email = document.getElementById('email');
//    const password = document.getElementById('password');

//    const setError = (element, message) => {
//        const inputControl = element.parentElement;
//        const errorDisplay = inputControl.querySelector('.error');

//        if (!errors[element.id]) {
//            errors[element.id] = [];
//        }

//        errors[element.id].push(message);

//        errorDisplay.innerText = errors[element.id].join(', ');
//        inputControl.classList.add('error');
//        inputControl.classList.remove('success');
//    };

//    const setSuccess = element => {
//        const inputControl = element.parentElement;
//        const errorDisplay = inputControl.querySelector('.error');

//        if (errors[element.id]) {
//            delete errors[element.id];  // Ensure errors are cleared when validation passes
//        }

//        errorDisplay.innerText = '';  // Clear the error message
//        inputControl.classList.remove('error');
//        inputControl.classList.add('success');
//    };


//    const validateSigninForm = () => {
//        const emailValue = email.value.trim();
//        const passwordValue = password.value.trim();

//        if (!emailValue) {
//            setError(email, 'Enter your email');
//        } else {
//            setSuccess(email);
//        }

//        if (!passwordValue) {
//            setError(password, 'Enter your password');
//        } else {
//            setSuccess(password)
//        }
//    }

//    validateSigninForm();
//}

//function signUpValidation() {
//    const firstName = document.getElementById('firstname');
//    const lastName = document.getElementById('lastname');
//    const confPassword = document.getElementById('conf-password');
//    const email = document.getElementById('email');
//    const password = document.getElementById('password');

//    const validateSignUpForm = () => {
//        const firstNameValue = firstName.value.trim();
//        const lastNameValue = lastName.value.trim();
//        const emailValue = email.value.trim();
//        const passwordValue = password.value.trim();
//        const confPasswordValue = confPassword.value.trim();

//        const errors = {};

//        const setError = (element, message) => {
//            const inputControl = element.parentElement;
//            const errorDisplay = inputControl.querySelector('.error');

//            if (!errors[element.id]) {
//                errors[element.id] = [];
//            }

//            errors[element.id].push(message);

//            errorDisplay.innerText = errors[element.id].join(', ');
//            inputControl.classList.add('error');
//            inputControl.classList.remove('success');
//        };

//        const setSuccess = element => {
//            const inputControl = element.parentElement;
//            const errorDisplay = inputControl.querySelector('.error');

//            if (errors[element.id]) {
//                delete errors[element.id];
//                errorDisplay.innerText = '';
//                inputControl.classList.remove('error');
//            }
//            inputControl.classList.add('success');
//        };

//        // Validation checks
//        if (!firstNameValue) {
//            setError(firstName, 'A first name must be provided.');
//        } else if (firstNameValue.length <= 2) {
//            setError(firstName, 'A name must contain 2 letters.');
//        } else {
//            setSuccess(firstName);
//        }

//        if (!lastNameValue) {
//            setError(lastName, 'A surname must be provided.');
//        } else if (lastNameValue.length <= 2) {
//            setError(lastName, 'A name must contain 2 letters.');
//        } else {
//            setSuccess(lastName);
//        }

//        if (!emailValue) {
//            setError(email, 'Email is required');
//        } else if (!isValidEmail(emailValue)) {
//            setError(email, 'Provide a valid email');
//        } else {
//            setSuccess(email);
//        }

//        if (!passwordValue) {
//            setError(password, 'Enter a password');
//        } else if (!isValidPassword(passwordValue)) {
//            setError(password, 'The password is not valid.');
//        } else {
//            setSuccess(password);
//        }

//        if (!confPasswordValue) {
//            setError(confPassword, 'Enter your password again.');
//        } else if (confPasswordValue !== passwordValue) {
//            setError(confPassword, 'The passwords are not the same');
//        } else {
//            setSuccess(confPassword);
//        }

//        // Return final result
//        return Object.keys(errors).length === 0;
//    };

//    function isValidEmail(email) {
//        var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
//        return emailRegex.test(email);
//    }

//    function isValidPassword(password) {
//        var passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z\d\s]).{8,}$/;
//        return passwordRegex.test(password);
//    }

//    validateSignUpForm();
//}


const formErrorHandler = (element, validationResult) => {
    let spanElement = document.querySelector(`[data-valmsg-for="${element.name}"]`)

    if (validationResult) {
        element.classList.remove('input-validation-error', 'error')
        spanElement.classList.remove('field-validation-error', 'error')
        spanElement.classList.add('field-validation-valid', 'success')
        spanElement.innerHTML = ""
    }
    else {
        element.classList.add('input-validation-error', 'error')
        spanElement.classList.add('field-validation-error', 'error')
        spanElement.classList.remove('field-validation-valid', 'success')
        spanElement.innerHTML = element.dataset.valRequired
    }
}

const compareValidator = (element, compareValue) => {
    if (element.value === compareValue)
        return true

    return false
}


const textValidator = (element, minLength = 2) => {
    if (element.value.length >= minLength) {
        formErrorHandler(element, true)
    } else {
        formErrorHandler(element, false)
    }
}

const textAreaValidator = (element, maxLength = 500) => {
    if (element.value.length >= maxLength) {
        formErrorHandler(element, true)
    } else {
        formErrorHandler(element, false)
    }
} 

const emailValidator = (element) => {
    const regEx = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    formErrorHandler(element, regEx.test(element.value))
}

const passwordValidator = (element) => {
    if (element.dataset.valEqualtoOther !== undefined) {
        let password = document.getElementsByName(element.dataset.valEqualtoOther.replace('*', 'Form'))[0].value

        if (element.value === password)
            formErrorHandler(element, true)
        else
            formErrorHandler(element, false)
    } else {
        //Minimum eight characters, at least one letter, one number and one special character
        const regEx = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/
        formErrorHandler(element, regEx.test(element.value))
    }
}

const checkboxValidator = (element) => {
    if (element.checked) {
        formErrorHandler(element, true)

    } else {
        formErrorHandler(element, false)
    }


}

let form = document.querySelectorAll('form')
let inputs = form[0].querySelectorAll('input')

inputs.forEach(input => {
    if (input.dataset.val === 'true') {
        if (input.type === 'checkbox') {
            input.addEventListener('change', (e) => {
                checkboxValidator(e.target)
            })
        }
        else {
            input.addEventListener('keyup', (e) => {
                switch (e.target.type) {
                    case 'text': 
                        textValidator(e.target)
                        break

                    case 'email':
                        emailValidator(e.target)
                        break

                    case 'password':
                        passwordValidator(e.target)
                        break

                    case 'textarea':
                        textAreaValidator(e.target)
                }
            })
        }
    }
})
