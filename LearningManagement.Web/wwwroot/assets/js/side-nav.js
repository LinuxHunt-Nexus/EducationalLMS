function Toggle(e) {
    let menuitem = document.querySelector('ul');
    e.name === 'menu' ? (e.name = 'arrow-back-outline') : (e.name = 'menu');
}




const getNavToggle=()=>{
    const i=document.querySelector('.icon');
    const menu=document.querySelector('.side-nav');
    i.addEventListener('click',()=>{
        menu.classList.toggle('nav-active');
        i.classList.toggle('white-icon');
    });
};

getNavToggle();