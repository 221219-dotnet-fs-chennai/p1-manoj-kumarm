const userElem = document.querySelector(".user__profile")
const API_URL = "https://localhost:7009/V1/api/ManageUser/me?"
const API_SKILL_UPDATE_URL = "https://localhost:7009/V1/api/ManageSkill/update?"
const API_LOC_UPDATE_URL = "https://localhost:7009/V1/api/ManageLocation/update?"
const API_USER_UPDATE_URL = "https://localhost:7009/V1/api/ManageUser/update?"
const API_COM_UPDATE_URL = "https://localhost:7009/V1/api/ManageCompany/update?"
const API_EDU_UPDATE_URL = "https://localhost:7009/V1/api/ManageEducation/update?"

const API_LOC_DELETE = "https://localhost:7009/V1/api/ManageLocation/delete?"
const API_SKILL_DELETE = "https://localhost:7009/V1/api/ManageSkill/delete?"
const API_COM_DELETE = "https://localhost:7009/V1/api/ManageCompany/delete?"
const API_EDU_DELETE = "https://localhost:7009/V1/api/ManageEducation/delete?"

let email = localStorage.getItem('email')
email = email.replace(/['‘’"“”]/g, '')

async function showUser() {
  userElem.innerHTML = ''
  await fetch(API_URL + new URLSearchParams({
      email: email
    }))
    .then(response => response.json())
    .then(users => {
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
        Updatebtn_details.addEventListener("click", () => {
          //show hide form
          detail.appendChild(detail_form)
          if (detail_form.style.display !== "none") {
            detail_form.style.display = "none"
          } else {
            detail_form.style.display = "block"
          }
          //fetch - put
          fetch(API_USER_UPDATE_URL + new URLSearchParams({
            email: email
          }), {
            method: "PUT",
            body: JSON.stringify({
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



        const addlocation = document.createElement('a')
        addlocation.style.display = "none"
        if (newUser.location.length == 0) {
          addlocation.textContent = "Add Location"
          addlocation.href = "./addLocation.html"
          addlocation.style.display = "block"
        } else {
          addlocation.style.direction = "none"
        }
        const locationDiv = document.createElement('div')
        locationDiv.appendChild(addlocation)
        locationDiv.className = "card__user__loc__grp"
        newUser.location.forEach(loc => {
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

          const delete_loc = document.createElement('button')
          delete_loc.className = "delete__btn"
          delete_loc.textContent = "Delete"
          locationDiv.appendChild(delete_loc)

          //delete
          delete_loc.addEventListener("click", (e) => {
            e.preventDefault()
            fetch(API_LOC_DELETE + new URLSearchParams({
              email: email
            }), {
              method: "DELETE",
              headers: {
                "Content-type": "application/json; charset=UTF-8",
              },
            }).then((response) => console.log(response))
          })


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
          Updatebtn_loc.addEventListener("click", () => {
            //show hide form
            locationDiv.appendChild(form__div)
            if (form__div.style.display !== "none") {
              form__div.style.display = "none"
            } else {
              form__div.style.display = "block"
            }
            //fetch - put
            fetch(API_LOC_UPDATE_URL + new URLSearchParams({
              email: email
            }), {
              method: "PUT",
              body: JSON.stringify({
                "zipcode": zipcode_input.value,
                "city": city_input.value
              }),
              headers: {
                "Content-type": "application/json; charset=UTF-8",
              },
            }).then((response) => console.log(response))
          })

        })



        const addskill = document.createElement('a')
          addskill.style.display = "none"
          if (newUser.skills.length == 0) {
            addskill.textContent = "Add Skill"
            addskill.href = "./addskill.html"
            addskill.style.display = "block"
          } else {
            addskill.style.direction = "none"
          }
        const skillGrp = document.createElement('div')
        skillGrp.className = "card__user__skill__grp"
        skillGrp.appendChild(addskill)

        newUser.skills.forEach(skill => {
          const skillDiv = document.createElement('div')
          // delete
          const Deletebtn_skill = document.createElement('button')
          Deletebtn_skill.className = "delete__btn"
          Deletebtn_skill.textContent = "Delete"
          // update
          const Updatebtn_skill = document.createElement('button')
          Updatebtn_skill.className = "update__btn"
          Updatebtn_skill.textContent = "Update"

          const skillnames = document.createElement('input')
          skillnames.value = skill
          skillnames.className = "card__user__skills"
          skillDiv.appendChild(skillnames)
          skillDiv.appendChild(Updatebtn_skill)
          skillDiv.appendChild(Deletebtn_skill)


          // const skillform = document.createElement('form')
          // skillform.className = "skill__form"
          // skillform.appendChild(document.createElement('input'))

          //delete
          Deletebtn_skill.addEventListener("click", (e) => {
            e.preventDefault()
            fetch(API_SKILL_DELETE + new URLSearchParams({
              email: email,
              skillname: skillnames.value
            }), {
              method: "DELETE",
              headers: {
                "Content-type": "application/json; charset=UTF-8",
              },
            }).then((response) => console.log(response))
          })

          //update
          Updatebtn_skill.addEventListener("click", (e) => {
            let newskill = Updatebtn_skill.onclick = prompt("enter the skill name")
            e.preventDefault()
            fetch(API_SKILL_UPDATE_URL + new URLSearchParams({
              email: email,
              oldskill: skillnames.value
            }), {
              method: "PUT",
              body: JSON.stringify({
                skill: newskill
              }),

              // Adding headers to the request
              headers: {
                "Content-type": "application/json; charset=UTF-8",
              },
            }).then((response) => console.log(response))
          })

          

          skillGrp.appendChild(skillDiv)
        })


        //Company
        const addcompany = document.createElement('a')
          addcompany.style.display = "none"
          if (newUser.companies.length == 0) {
            addcompany.textContent = "Add Companies"
            addcompany.href = "./addcompany.html"
            addcompany.style.display = "block"
          } else {
            addcompany.style.direction = "none"
          }
        const companiesgrp = document.createElement('article')
        const companyDiv1 = document.createElement('div')
        companiesgrp.appendChild(addcompany)
        newUser.companies.forEach(comp => {
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

          //update 
          const Updatebtn_comp = document.createElement('button')
          Updatebtn_comp.className = "update__btn"
          Updatebtn_comp.textContent = "Update"

          // delete
          const Deletebtn_comp = document.createElement('button')
          Deletebtn_comp.className = "delete__btn"
          Deletebtn_comp.textContent = "Delete"

          // on click - update

          const compform = document.createElement('form')
          compform.className = "comp__form"
          const comp_name_input = document.createElement('input')
          const comp_title_input = document.createElement('input')
          const comp_start_input = document.createElement('input')
          const comp_end_input = document.createElement('input')
          const name_lable = document.createElement('lable')
          name_lable.textContent = "Company Name"
          const title_lable = document.createElement('lable')
          title_lable.textContent = "Title"
          const start_lable = document.createElement('lable')
          start_lable.textContent = "Start Year"
          const end_lable = document.createElement('lable')
          end_lable.textContent = "End Year"
          compform.appendChild(name_lable)
          compform.appendChild(comp_name_input)
          compform.appendChild(title_lable)
          compform.appendChild(comp_title_input)
          compform.appendChild(start_lable)
          compform.appendChild(comp_start_input)
          compform.appendChild(end_lable)
          compform.appendChild(comp_end_input)

          const compformDiv = document.createElement('div')
          compformDiv.className = "comp_form_grp"
          //compformDiv.appendChild(Updatebtn_comp)
          compformDiv.appendChild(Deletebtn_comp)

          //delete
          Deletebtn_comp.addEventListener("click", (e) => {
            e.preventDefault()
            fetch(API_COM_DELETE + new URLSearchParams({
              email: email,
              comapanyName: comp_name.value
            }), {
              method: "DELETE",
              headers: {
                "Content-type": "application/json; charset=UTF-8",
              },
            }).then((response) => console.log(response))
          })


          //update
          Updatebtn_comp.addEventListener("click", (e) => {
            companyDiv1.appendChild(compform)
            e.preventDefault()
            if (compform.style.display !== "none") {
              compform.style.display = "none"
            } else {
              compform.style.display = "block"
            }
            fetch(API_COM_UPDATE_URL + new URLSearchParams({
              email: email,
              companyName: comp.companyname
            }), {
              method: "PUT",
              body: JSON.stringify({
                "companyname": comp_name_input.value,
                "title": comp_title_input.value,
                "startyear": comp_start_input.value,
                "endyear": comp_end_input.value
              }),
              headers: {
                "Content-type": "application/json; charset=UTF-8",
              },
            }).then((response) => console.log(response))

          })

          companyDiv1.appendChild(Updatebtn_comp)
          companyDiv1.appendChild(Deletebtn_comp)
          companiesgrp.appendChild(companyDiv1)

        })

        //Education
        const educationgrp = document.createElement('article')
        const addeducation = document.createElement('a')
          addeducation.style.display = "none"
          if (newUser.education.length == 0) {
            addeducation.textContent = "Add Education"
            addeducation.href = "./addeducation.html"
            addeducation.style.display = "block"
          } else {
            addeducation.style.direction = "none"
          }
          educationgrp.appendChild(addeducation)
        newUser.education.forEach(comp => {
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

          const edu_gpa = document.createElement('input')
          edu_gpa.value = comp.gpa
          edu_gpa.className = "card__comp__name"
          educationDiv.appendChild(edu_gpa)

          const edu_s_date = document.createElement('input')
          edu_s_date.value = comp.startdate
          edu_s_date.className = "card__comp__name"
          educationDiv.appendChild(edu_s_date)

          const edu__e_date = document.createElement('input')
          edu__e_date.value = comp.enddate
          edu__e_date.className = "card__comp__name"
          educationDiv.appendChild(edu__e_date)

          const education_update_div = document.createElement('div')

          // delete
          const Deletebtn_edu = document.createElement('button')
          Deletebtn_edu.className = "delete__btn"
          Deletebtn_edu.textContent = "Delete"

          // on click - delete
          Deletebtn_edu.addEventListener("click", (e) => {
            e.preventDefault()
            fetch(API_EDU_DELETE + new URLSearchParams({
              email: email,
              eduname:edu_name.value
            }),{
              method:"DELETE",
              headers: {
                "Content-type": "application/json; charset=UTF-8",
              },
            }).then((response) => console.log(response))
          })


          //update  
          const Updatebtn_edu = document.createElement('button')
          Updatebtn_edu.className = "update__btn"
          Updatebtn_edu.textContent = "Update"

          // on click - update

          const eduform = document.createElement('form')
          eduform.className = "edu__form"
          const edu_input_name = document.createElement('input')
          const edu_degree_input = document.createElement('input')
          const edu_start_input = document.createElement('input')
          const edu_end_input = document.createElement('input')
          const edu_gpa_input = document.createElement('input')
          const name_lable = document.createElement('lable')
          const gpa_lable = document.createElement('lable')
          const start_lable = document.createElement('lable')
          const deg_lable = document.createElement('lable')
          const end_lable = document.createElement('lable')
          name_lable.textContent = "Instuite Name"
          deg_lable.textContent = "Degree Name"
          gpa_lable.textContent = "GPA"
          start_lable.textContent = "Start Year"
          end_lable.textContent = "End Year"
          eduform.appendChild(name_lable)
          eduform.appendChild(edu_input_name)
          eduform.appendChild(deg_lable)
          eduform.appendChild(edu_degree_input)
          eduform.appendChild(gpa_lable)
          eduform.appendChild(edu_gpa_input)
          eduform.appendChild(start_lable)
          eduform.appendChild(edu_start_input)
          eduform.appendChild(end_lable)
          eduform.appendChild(edu_end_input)

          const eduformDiv = document.createElement('div')
          eduformDiv.className = "comp_form_grp"
          eduformDiv.appendChild(Updatebtn_edu)

          Updatebtn_edu.addEventListener("click", (e) => {
            educationDiv.appendChild(eduform)
            if (eduform.style.display !== "none") {
              eduform.style.display = "none"
            } else {
              eduform.style.display = "block"
            }
            e.preventDefault()
            fetch(API_EDU_UPDATE_URL + new URLSearchParams({
              email: email,
              eduname: comp.institute
            }), {
              method: "PUT",
              body: JSON.stringify({
                "institute": edu_input_name.value,
                "degreename": edu_degree_input.value,
                "gpa": edu_gpa_input.value,
                "startdate": edu_start_input.value,
                "enddate": edu_end_input.value
              }),
              headers: {
                "Content-type": "application/json; charset=UTF-8",
              },
            }).then((response) => console.log(response))

          })


          educationDiv.appendChild(Updatebtn_edu)
          educationDiv.appendChild(Deletebtn_edu)
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