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

/*Darkmode toggle*/

document.addEventListener('DOMContentLoaded', function () {
    let sw = document.querySelector('#switch-mode')

    sw.addEventListener('change', function () {
        let theme = this.checked ? "dark" : "light"

        fetch(`/settings/changetheme?theme=${theme}`)
            .then(res => {
                if (res.ok)
                    window.location.reload()
                else 
                    console.log('Error changing theme')
            })
    })
})
