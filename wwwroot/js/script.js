const primaryNav = document.querySelector('.nav-menu')
const navToggle = document.querySelector('.mobile-nav-toggle')


navToggle.addEventListener('click', () => {
    const visibility = primaryNav.getAttribute("data-visible");

    if (visibility === "false") {
        primaryNav.setAttribute('data-visible', true)
        navToggle.setAttribute('aria-expanded', true)
    } else if (visibility === "true") {
        primaryNav.setAttribute('data-visible', false)
        navToggle.setAttribute('aria-expanded', false)
    }
});


//script and styling has been picked up from here. https://codepen.io/costdev/pen/NWqyqXb
/*clickAndSelect()*/

//function clickAndSelect() {
//  let cards = Array.from( document.querySelectorAll('.card') ),
//      elements = []
  
//  // Add child nodes to clickable elements
//  cards.forEach(card => {
//    elements = elements.concat( Array.from(card.children) )
//  })

//  // Attach to mouse events
//  elements.forEach(element => {
    
//    // click: Disable
//    element.addEventListener('click', e => e.preventDefault())
    
//    // mousedown: Log the timestamp
//    element.addEventListener('mousedown', e => {
//      let card = e.target.closest(".card")
//      card.setAttribute('data-md', Date.now())
//    })
    
//    // mouseup: Determine whether to click
//    element.addEventListener('mouseup', e => {
      
//      // Only one please
//      e.stopPropagation();

//      let card = (e.target.classList.contains("card")) ? e.target : e.target.closest('.card'),
//          then = card.getAttribute('data-md'),
//          now = Date.now()

//      // Allow 200ms to distinguish click from non-click
//      if(now - then < 200) {
        
//        // Visit the link in the card
//        // Change 'a' to a class if you have multiple links
//        window.location = card.querySelector('a').href
    
//        // Remove for production
//        card.classList.add('visited')
//        console.log(card.querySelector('a').href)
        
//      }
  
//      // Clean up
//      card.removeAttribute('data-md')
      
//    })
//  })
//}

//login - form validation

//document.addEventListener('DOMContentLoaded', function () {
//    const signInForm = document.querySelector('.signin-form');

//    signInForm.addEventListener('submit', (e) => {
//        e.preventDefault();
//        SignInvValidation();
//    });


//    function SignInvValidation() {


//        const email = document.getElementById('email');
//        const password = document.getElementById('password');

//        const setError = (element, message) => {
//            const inputControl = element.parentElement;
//            const errorDisplay = inputControl.querySelector('.error');

//            errorDisplay.innerText = message;
//            inputControl.classList.add('error');
//            inputControl.classList.remove('success');

//            console.log('Error has triggered!')
//        }

//        const setSuccess = element => {
//            const inputControl = element.parentElement;
//            const errorDisplay = inputControl.querySelector('.error');

//            errorDisplay.innerText = '';
//            inputControl.classList.add('success');
//            inputControl.classList.remove('error');

//            console.log('Success has triggered!')
//        }

//        const validateSigninForm = () => {
//            const emailValue = email.value.trim();
//            const passwordValue = password.value.trim();

//            if (!emailValue) {
//                setError(email, 'Email is required');
//            } else if (!isValidEmail(emailValue)) {
//                setError(email, 'Provide a valid email');
//            } else {
//                setSuccess(email);
//            }

//            if (!passwordValue) {
//                setError(password, 'Enter a password');
//            } else {
//                setSuccess(password)
//            }

//            function isValidEmail(email) {
//                var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
//                return emailRegex.test(email);
//            }
//        }

//        validateSigninForm
//    }


//});

//Sign up validation

document.addEventListener('DOMContentLoaded', function () {
    const signupForm = document.querySelector('.signup-form');

    signupForm.addEventListener('submit', (e) => {
        if (!signUpValidation()) {
            e.preventDefault();
        }
    });


    function signUpValidation() {
        const firstName = document.getElementById('firstname');
        const lastName = document.getElementById('lastname');
        const confPassword = document.getElementById('conf-password');
        const email = document.getElementById('email');
        const password = document.getElementById('password');

        const validateSignUpForm = () => {
            const firstNameValue = firstName.value.trim();
            const lastNameValue = lastName.value.trim();
            const emailValue = email.value.trim();
            const passwordValue = password.value.trim();
            const confPasswordValue = confPassword.value.trim();

            const setError = (element, message) => {
                const inputControl = element.parentElement;
                const errorDisplay = inputControl.querySelector('.error');

                errorDisplay.innerText = message;
                inputControl.classList.add('error');
                inputControl.classList.remove('success');
            }

            const setSuccess = element => {
                const inputControl = element.parentElement;
                const errorDisplay = inputControl.querySelector('.error');

                errorDisplay.innerText = '';
                inputControl.classList.add('success');
                inputControl.classList.remove('error');
            }

            // Validation checks
            if (!firstNameValue) {
                setError(firstName, 'A first name must be provided.');
                return false;
            } else if (firstNameValue.length < 2) {
                setError(firstName, 'A name must contain more than 2 letters.');
                return false;
            } else {
                setSuccess(firstName);
            }

            if (!lastNameValue) {
                setError(lastName, 'A surname must be provided.');
                return false;
            } else if (lastNameValue.length < 2) {
                setError(lastName, 'A name must contain more than 2 letters.');
                return false;
            } else {
                setSuccess(lastName);
            }

            if (!emailValue) {
                setError(email, 'Email is required');
                return false;
            } else if (!isValidEmail(emailValue)) {
                setError(email, 'Provide a valid email');
                return false;
            } else {
                setSuccess(email);
            }

            if (!passwordValue) {
                setError(password, 'Enter a password');
                return false;
            } else if (!isValidPassword(passwordValue)) {
                setError(password, 'The password you have entered is not valid.')
                return false;
            } else {
                setSuccess(password);
            }

            if (!confPasswordValue) {
                setError(confPassword, 'Enter your password again.');
                return false;
            } else if (confPasswordValue !== passwordValue) {
                setError(confPassword, 'The passwords are not the same');
                return false;
            } else {
                setSuccess(confPassword);
            }

            // All validations passed
            return true;
        }

        function isValidEmail(email) {
            var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            return emailRegex.test(email);
        }

        function isValidPassword(password) {
            var passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z\d\s]).{8,}$/;
            return passwordRegex.test(password);
        }

        return validateSignUpForm();
    }

});


//Darkmode toggle

//document.addEventListener('DOMContentLoaded', () => {
//    const switcher = document.getElementById('theme-switcher');

//    // Apply the theme on initial load
//    if (localStorage.getItem('theme') === 'dark' || (!('theme' in localStorage) && window.matchMedia('(prefers-color-scheme: dark)').matches)) {
//        document.documentElement.setAttribute('data-theme', 'dark');
//        switcher.checked = true;
//    } else {
//        document.documentElement.setAttribute('data-theme', 'light');
//    }

//    // Listen for toggle of the theme switch
//    switcher.addEventListener('change', function () {
//        console.log('theme changed')
//        if (this.checked) {
//            document.documentElement.setAttribute('data-theme', 'dark');
//            localStorage.setItem('theme', 'dark');
//        } else {
//            document.documentElement.setAttribute('data-theme', 'light');
//            localStorage.setItem('theme', 'light');
//        }
//    });
//}));
