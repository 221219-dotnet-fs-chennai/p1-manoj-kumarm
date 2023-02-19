const userElem = document.querySelector(".user__profile")
const API_URL = "https://localhost:7009/V1/api/ManageUser/me?"
const API_SKILL_UPDATE_URL = "https://localhost:7009/V1/api/ManageSkill/update?"
const API_LOC_UPDATE_URL = "https://localhost:7009/V1/api/ManageLocation/update?"
const API_USER_UPDATE_URL = "https://localhost:7009/V1/api/ManageUser/update?"

let email = localStorage.getItem('email') 
email = email.replace(/['‘’"“”]/g, '')

async function showUser(){
  userElem.innerHTML =''
  await fetch(API_URL + new URLSearchParams({email:email}))
    .then(response => response.json())
    .then(users =>{
      users.forEach(newUser => {
        console.log(newUser);
        const parentDiv = document.createElement('div')
        parentDiv.className = "container"
  
        const div = document.createElement('div')
        div.className = "card__grp"
  
        const detail = document.createElement('div')
        detail.className = "detail__card"
        const name = document.createElement('input')
        name.value = newUser.name
        name.className = "user__name"
        detail.appendChild(name)
        const phone = document.createElement('input')
        phone.value = newUser.phone
        phone.className = "user__name"
        detail.appendChild(phone)
        const website = document.createElement('input')
        website.value = newUser.website
        website.className = "user__name"
        detail.appendChild(website)
        const gender = document.createElement('input')
        gender.value = newUser.gender
        gender.className = "user__name"
        detail.appendChild(gender)
        const age = document.createElement('input')
        age.value = newUser.age
        age.className = "user__name"
        detail.appendChild(age)
        const aboutMe = document.createElement('input')
        aboutMe.value = newUser.aboutMe
        aboutMe.className = "user__name"
        detail.appendChild(aboutMe)

        
        //form
        const user_details_grp = document.createElement('div')
        const Update_user_div = document.createElement('div')
        Update_user_div.className = "user_details_form_div"
        const detail_form = document.createElement('form')
        detail_form.className = "details__form"

        const nameLable = document.createElement('label')
        nameLable.textContent = "Name"
        const name_input = document.createElement('input')
        name_input.className = "name_form_input"
        detail_form.appendChild(nameLable)
        detail_form.appendChild(name_input)

        const phoneLable = document.createElement('label')
        phoneLable.textContent = "Phone"
        const phone_input = document.createElement('input')
        phone_input.className = "phone_form_input"
        detail_form.appendChild(phoneLable)
        detail_form.appendChild(phone_input)

        const websiteLable = document.createElement('label')
        websiteLable.textContent = "Website"
        const website_input = document.createElement('input')
        website_input.className = "website_form_input"
        detail_form.appendChild(websiteLable)
        detail_form.appendChild(website_input)

        const genderLable = document.createElement('label')
        genderLable.textContent = "Gender"
        const gender_input = document.createElement('input')
        gender_input.className = "gender_form_input"
        detail_form.appendChild(genderLable)
        detail_form.appendChild(gender_input)

        const ageLable = document.createElement('label')
        ageLable.textContent = "Age"
        const age_input = document.createElement('input')
        age_input.className = "age_form_input"
        detail_form.appendChild(ageLable)
        detail_form.appendChild(age_input)

        const aboutmeLable = document.createElement('label')
        aboutmeLable.textContent = "Aboutme"
        const aboutme_input = document.createElement('input')
        age_input.className = "aboutme_form_input"
        detail_form.appendChild(aboutmeLable)
        detail_form.appendChild(aboutme_input)

        
        //user_details_grp.appendChild(Update_user_div)
        const Updatebtn_details = document.createElement('button')
        Updatebtn_details.className = "update__btn"
        Updatebtn_details.textContent = "Update"
        detail.appendChild(Updatebtn_details)

        //Fetch - PUT
        Updatebtn_details.addEventListener("click",()=>{
          //show hide form
          detail.appendChild(detail_form)
          if(detail_form.style.display !== "none"){
            detail_form.style.display = "none"
          }else{
            detail_form.style.display = "block"
          }
          //fetch - put
          fetch(API_USER_UPDATE_URL + new URLSearchParams({email:email}),{
            method:"PUT",
            body:JSON.stringify({
              "fullname": name_input.value,
              "phone": phone_input.value,
              "website": website_input.value,
              "aboutme": aboutme_input.value,
              "gender": gender_input.value,
              "age": age_input.value
            }),
            headers: {
              "Content-type": "application/json; charset=UTF-8",
            },
          }).then((response) => console.log(response))
        })


        
        
        const locationDiv = document.createElement('div')
        locationDiv.className = "card__user__loc__grp"
        newUser.location.forEach(loc =>{
          const userlocationcity = document.createElement('input')
          userlocationcity.value = loc.city
          userlocationcity.className = "card__user__city"
          const userlocationzipcode = document.createElement('input')
          userlocationzipcode.value = loc.zipcode
          userlocationcity.className = "card__user__zipcode"
          locationDiv.appendChild(userlocationcity)
          locationDiv.appendChild(userlocationzipcode)

          //button
          const Updatebtn_loc = document.createElement('button')
          Updatebtn_loc.className = "update__btn"
          Updatebtn_loc.textContent = "Update"
          locationDiv.appendChild(Updatebtn_loc)
          
          //form
          const form__div = document.createElement('div')
          const location_form = document.createElement('form')
          location_form.className = "location__form"
          
          const zipcode_lable = (document.createElement('lable'))
          zipcode_lable.textContent = "zipcode"
          const city_lable = (document.createElement('lable'))
          city_lable.textContent = "city"
          location_form.appendChild(zipcode_lable)
          const zipcode_input = document.createElement('input')
          location_form.appendChild(zipcode_input)
          location_form.appendChild(city_lable)
          const city_input = document.createElement('input')
          location_form.appendChild(city_input)
          form__div.className = "update__location__form"
          form__div.appendChild(location_form)
          
          //Fetch - PUT
          Updatebtn_loc.addEventListener("click",()=>{
            //show hide form
            locationDiv.appendChild(form__div)
            if(form__div.style.display !== "none"){
              form__div.style.display = "none"
            }else{
              form__div.style.display = "block"
            }
            //fetch - put
            fetch(API_LOC_UPDATE_URL + new URLSearchParams({email:email}),{
              method:"PUT",
              body:JSON.stringify({
                "zipcode": zipcode_input.value,
                "city": city_input.value
              }),
              headers: {
                "Content-type": "application/json; charset=UTF-8",
              },
            }).then((response) => console.log(response))
          })
          
        }) 

        const skillGrp = document.createElement('div')
        skillGrp.className = "card__user__skill__grp"
        newUser.skills.forEach(skill => {
          const skillDiv = document.createElement('div')
          const Updatebtn_skill = document.createElement('button')
          Updatebtn_skill.className = "update__btn"
          Updatebtn_skill.textContent = "Update"
          // on click --DOING

          const skillnames = document.createElement('input')
          skillnames.value = skill
          skillnames.className = "card__user__skills"
          skillDiv.appendChild(skillnames)
          skillDiv.appendChild(Updatebtn_skill)

          
          // const skillform = document.createElement('form')
          // skillform.className = "skill__form"
          // skillform.appendChild(document.createElement('input'))
          
          Updatebtn_skill.addEventListener("click", (e) => {
            let newskill =Updatebtn_skill.onclick = prompt("enter the skill name")
            //let newskill = skillnames.setAttribute("value", skillnames.value)
            e.preventDefault()
            // skillDiv.appendChild(skillform)
            // if(skillform.style.display !== "none"){
            //   skillform.style.display = "none"
            // }else{
            //   skillform.style.display = "block"
            // }
            
            
            fetch(API_SKILL_UPDATE_URL + new URLSearchParams({email: email, oldskill:skillnames.value}),{
              method:"PUT",
              body: JSON.stringify({
                skill: newskill
              }),
          
              // Adding headers to the request
              headers: {
                "Content-type": "application/json; charset=UTF-8",
              },  
            }
            ).then((response) => console.log(response))
          })
          
          skillGrp.appendChild(skillDiv)
        })

        const companiesgrp = document.createElement('article')
        newUser.companies.forEach(comp => {
          const Updatebtn_comp = document.createElement('button')
          Updatebtn_comp.className = "update__btn"
          Updatebtn_comp.textContent = "Update"
          // on click --TODO
          const companyDiv1 = document.createElement('div')
          companyDiv1.className = "card__user__comp__grp"
          const comp_name = document.createElement('input')
          comp_name.value = comp.companyname
          comp_name.className = "card__comp__name"
          companyDiv1.appendChild(comp_name)

          const comp_title = document.createElement('input')
          comp_title.value = comp.title
          comp_title.className = "card__comp__name"
          companyDiv1.appendChild(comp_title)

          const comp_s_date = document.createElement('input')
          comp_s_date.value = comp.startyear
          comp_s_date.className = "card__comp__name"
          companyDiv1.appendChild(comp_s_date)

          const comp_e_date = document.createElement('input')
          comp_e_date.value = comp.endyear
          comp_e_date.className = "card__comp__name"
          companyDiv1.appendChild(comp_e_date)
          
          companyDiv1.appendChild(Updatebtn_comp)
          companiesgrp.appendChild(companyDiv1)

        })

        const educationgrp = document.createElement('article')
        newUser.education.forEach(comp => {
          const Updatebtn_edu = document.createElement('button')
          Updatebtn_edu.className = "update__btn"
          Updatebtn_edu.textContent = "Update"
          // on click --TODO
          
          const educationDiv = document.createElement('div')
          educationDiv.className = "card__user__comp__grp"
          const edu_name = document.createElement('input')
          edu_name.value = comp.institute
          edu_name.className = "card__comp__name"
          educationDiv.appendChild(edu_name)

          const edu_deg = document.createElement('input')
          edu_deg.value = comp.degreename
          edu_deg.className = "card__comp__name"
          educationDiv.appendChild(edu_deg)

          const edu_s_date = document.createElement('input')
          edu_s_date.value = comp.startdate
          edu_s_date.className = "card__comp__name"
          educationDiv.appendChild(edu_s_date)

          const edu__e_date = document.createElement('input')
          edu__e_date.value = comp.enddate
          edu__e_date.className = "card__comp__name"
          educationDiv.appendChild(edu__e_date)
          
          educationDiv.appendChild(Updatebtn_edu)
          educationgrp.appendChild(educationDiv)

        })

        
        
        
        div.appendChild(detail)
        div.appendChild(locationDiv)
        div.appendChild(skillGrp)
        div.appendChild(educationgrp)
        div.appendChild(companiesgrp)
        parentDiv.appendChild(div)
        userElem.appendChild(parentDiv)
        
      });
    })
}

window.addEventListener("load", (event) => {
  showUser(); // already declared somewhere else
});