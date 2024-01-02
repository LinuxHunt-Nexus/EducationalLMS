function Submenu(e) {
    e.name === 'add-circle-sharp' ? (e.name = 'remove-circle-sharp') : (e.name = 'add-circle-sharp');
}



const sideNavToggle=()=>{
    const i=document.querySelector('.side-menu');
    const menu=document.querySelector('.nav-div');
    i.addEventListener('click',()=>{
        menu.classList.toggle('side-active');
        i.classList.toggle('white-icon2');
        console.log('clicked');
    });
};

sideNavToggle();