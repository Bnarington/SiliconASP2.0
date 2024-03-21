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
clickAndSelect()

function clickAndSelect() {
  let cards = Array.from( document.querySelectorAll('.card') ),
      elements = []
  
  // Add child nodes to clickable elements
  cards.forEach(card => {
    elements = elements.concat( Array.from(card.children) )
  })

  // Attach to mouse events
  elements.forEach(element => {
    
    // click: Disable
    element.addEventListener('click', e => e.preventDefault())
    
    // mousedown: Log the timestamp
    element.addEventListener('mousedown', e => {
      let card = e.target.closest(".card")
      card.setAttribute('data-md', Date.now())
    })
    
    // mouseup: Determine whether to click
    element.addEventListener('mouseup', e => {
      
      // Only one please
      e.stopPropagation();

      let card = (e.target.classList.contains("card")) ? e.target : e.target.closest('.card'),
          then = card.getAttribute('data-md'),
          now = Date.now()

      // Allow 200ms to distinguish click from non-click
      if(now - then < 200) {
        
        // Visit the link in the card
        // Change 'a' to a class if you have multiple links
        window.location = card.querySelector('a').href
    
        // Remove for production
        card.classList.add('visited')
        console.log(card.querySelector('a').href)
        
      }
  
      // Clean up
      card.removeAttribute('data-md')
      
    })
  })
}

//Darkmode toggle

document.addEventListener('DOMContentLoaded', () => {
    const switcher = document.getElementById('theme-switcher');

    // Apply the theme on initial load
    if (localStorage.getItem('theme') === 'dark' || (!('theme' in localStorage) && window.matchMedia('(prefers-color-scheme: dark)').matches)) {
        document.documentElement.setAttribute('data-theme', 'dark');
        switcher.checked = true;
    } else {
        document.documentElement.setAttribute('data-theme', 'light');
    }

    // Listen for toggle of the theme switch
    switcher.addEventListener('change', function () {
        console.log('theme changed')
        if (this.checked) {
            document.documentElement.setAttribute('data-theme', 'dark');
            localStorage.setItem('theme', 'dark');
        } else {
            document.documentElement.setAttribute('data-theme', 'light');
            localStorage.setItem('theme', 'light');
        }
    });
});
