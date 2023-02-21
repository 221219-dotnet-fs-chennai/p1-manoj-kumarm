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

var flag = false
let email = localStorage.getItem('email')
email = email.replace(/['‘’"“”]/g, '')

const delDiv = document.createElement('div')
delDiv.className = "main__container"

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
        const detail_heading = document.createElement('h4')
        const location_heading = document.createElement('h4')
        const skill_heading = document.createElement('h4')
        const education_heading = document.createElement('h4')
        const company_heading = document.createElement('h4')
        detail_heading.className = "personal__heading"
        location_heading.className = "personal__heading"
        skill_heading.className = "personal__heading"
        education_heading.className = "personal__heading"
        company_heading.className = "personal__heading"
        detail_heading.textContent = "Personal Details"
        location_heading.textContent ="Location Details"
        skill_heading.textContent ="Skill Details"
        education_heading.textContent ="Education Details"
        company_heading.textContent ="Experience Details"

        //detail.appendChild(detail_heading)
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
        user_details_grp.className = "user__form__and__inputs"
        const Update_user_div = document.createElement('div')
        Update_user_div.className = "user_details_form_div"
        const detail_form = document.createElement('form')
        Update_user_div.appendChild(detail_form)
        detail_form.className = "details__form"
        user_details_grp.appendChild(detail_form)
        detail.appendChild(Update_user_div)

        const name_input = document.createElement('input')
        name_input.placeholder = "Name"
        name_input.className = "name_form_input"
        detail_form.appendChild(name_input)

        const phone_input = document.createElement('input')
        phone_input.placeholder = "Phone"
        phone_input.className = "phone_form_input"
        detail_form.appendChild(phone_input)

        const websiteLable = document.createElement('label')
        websiteLable.textContent = "Website"
        const website_input = document.createElement('input')
        website_input.placeholder = "Website"
        website_input.className = "website_form_input"
        detail_form.appendChild(website_input)

        const genderLable = document.createElement('label')
        genderLable.textContent = "Gender"
        const gender_input = document.createElement('input')
        gender_input.placeholder = "Gender"
        gender_input.className = "gender_form_input"
        detail_form.appendChild(gender_input)

        const ageLable = document.createElement('label')
        ageLable.textContent = "Age"
        const age_input = document.createElement('input')
        age_input.className = "age_form_input"
        age_input.placeholder = "Age"
        detail_form.appendChild(age_input)

        const aboutmeLable = document.createElement('label')
        aboutmeLable.textContent = "Aboutme"
        const aboutme_input = document.createElement('input')
        aboutme_input.className = "aboutme_form_input"
        aboutme_input.placeholder = "About Me"
        detail_form.appendChild(aboutme_input)


        //user_details_grp.appendChild(Update_user_div)
        const Updatebtn_details = document.createElement('button')
        Updatebtn_details.className = "update__btn"
        Updatebtn_details.textContent = "Update"
        detail.appendChild(Updatebtn_details)
        const icon1 = document.createElement('i')
        icon1.className = "fa-solid fa-square-pen"  
        Updatebtn_details.appendChild(icon1)

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
          }).then((response) => {
            if(response.status == 201) flag = true
            else{
              flag = false
            }
          })
        })



        const addlocation = document.createElement('a')
        addlocation.className = "add_link"
        addlocation.style.display = "none"
        if (newUser.location.length == 0) {
          addlocation.textContent = "Add Location"
          addlocation.href = "../html/addlocation.html"
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

          //update
          const Updatebtn_loc = document.createElement('button')
          Updatebtn_loc.className = "update__btn"
          Updatebtn_loc.textContent = "Update"
          locationDiv.appendChild(Updatebtn_loc)
          const icon2 = document.createElement('i')
          icon2.className = "fa-solid fa-square-pen"
          Updatebtn_loc.appendChild(icon2)

          //delete
          const delete_loc = document.createElement('button')
          delete_loc.className = "delete__btn"
          delete_loc.textContent = "Delete"
          const icon9 = document.createElement('i')
          icon9.className = "fa-solid fa-delete-left"
          delete_loc.appendChild(icon9)
          locationDiv.appendChild(delete_loc)

          //delete
          delete_loc.addEventListener("click", (e) => {
            //e.preventDefault()
            fetch(API_LOC_DELETE + new URLSearchParams({
              email: email
            }), {
              method: "DELETE",
              headers: {
                "Content-type": "application/json; charset=UTF-8",
              },
            }).then((response) => {
              if(response.status == 204) flag = true
              else flag = false
            })
          })


          //form
          const form__div = document.createElement('div')
          const location_form = document.createElement('form')
          location_form.className = "location__form"

          const zipcode_lable = (document.createElement('lable'))
          zipcode_lable.textContent = "zipcode"
          const city_lable = (document.createElement('lable'))
          city_lable.textContent = "city"
          // location_form.appendChild(zipcode_lable)
          const zipcode_input = document.createElement('input')
          location_form.appendChild(zipcode_input)
          zipcode_input.placeholder = "Zipcode"
          // location_form.appendChild(city_lable)
          const city_input = document.createElement('input')
          location_form.appendChild(city_input)
          city_input.placeholder = "City"
          form__div.className = "update__location__form"
          form__div.appendChild(location_form)

          //Fetch - PUT
          Updatebtn_loc.addEventListener("click", () => {
            locationDiv.appendChild(form__div)
            //show hide form
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
            }).then((response) => {
              if(response.status == 201) flag = true
              else flag = false
            })
          })

        })



        const addskill = document.createElement('a')
        addskill.className = "add_link"
          if (newUser.skills.length < 3) {
            addskill.textContent = "Add Skill"
            addskill.href = "../html/addskills.html"
            addskill.style.display = "block"
          } else {
            addskill.style.direction = "none"
          }
        const skillGrp = document.createElement('div')
        skillGrp.className = "card__user__skill__grp"
        skillGrp.appendChild(addskill)

        newUser.skills.forEach(skill => {
          const skillDiv = document.createElement('div')
          skillDiv.className = "skill__div"
          // delete
          const Deletebtn_skill = document.createElement('button')
          Deletebtn_skill.className = "delete__btn"
          Deletebtn_skill.textContent = "Delete"
          const icon8 = document.createElement('i')
          icon8.className = "fa-solid fa-delete-left"
          Deletebtn_skill.appendChild(icon8)

          // update
          const Updatebtn_skill = document.createElement('button')
          Updatebtn_skill.className = "update__btn"
          Updatebtn_skill.textContent = "Update"
          const icon3 = document.createElement('i')
          icon3.className = "fa-solid fa-square-pen"
          Updatebtn_skill.appendChild(icon3)

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
            }).then((response) => {
              if(response.status == 204) flag = true
              else flag = false
            })
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
            }).then((response) => {
              if(response.status == 201) flag = true
              else flag = false
            })
          })

          

          skillGrp.appendChild(skillDiv)
        })


        //Company
        const addcompany = document.createElement('a')
        addcompany.className = "add_link"
          addcompany.style.display = "none"
          if (newUser.companies.length < 3) {
            addcompany.textContent = "Add Companies"
            addcompany.href = "../html/addCompany.html"
            addcompany.style.display = "block"
          } else {
            addcompany.style.direction = "none"
          }
        const companiesgrp = document.createElement('article')

        companiesgrp.className = "company_grp"
        const companyDiv1 = document.createElement('div')
        companyDiv1.className = "company_card"
        companiesgrp.appendChild(addcompany)
        companiesgrp.appendChild(companyDiv1)
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
          const icon10 = document.createElement('i')
          icon10.className = "fa-solid fa-square-pen"
          Updatebtn_comp.appendChild(icon10)

          // delete
          const Deletebtn_comp = document.createElement('button')
          Deletebtn_comp.className = "delete__btn"
          Deletebtn_comp.textContent = "Delete"
          const icon7 = document.createElement('i')
          icon7.className = "fa-solid fa-delete-left"
          Deletebtn_comp.appendChild(icon7)

          // on click - update

          const compform = document.createElement('form')
          compform.className = "comp__form"
          const comp_name_input = document.createElement('input')
          comp_name_input.placeholder = "Company Name"
          const comp_title_input = document.createElement('input')
          comp_title_input.placeholder = "Title"
          const comp_start_input = document.createElement('input')
          comp_start_input.placeholder = "Start Date"
          const comp_end_input = document.createElement('input')
          comp_end_input.placeholder = "End Date"
          const name_lable = document.createElement('lable')
          name_lable.textContent = "Company Name"
          const title_lable = document.createElement('lable')
          title_lable.textContent = "Title"
          const start_lable = document.createElement('lable')
          start_lable.textContent = "Start Year"
          const end_lable = document.createElement('lable')
          end_lable.textContent = "End Year"
          compform.appendChild(comp_name_input)
          compform.appendChild(comp_title_input)
          compform.appendChild(comp_start_input)
          compform.appendChild(comp_end_input)

          const compformDiv = document.createElement('div')
          compformDiv.className = "comp_form_grp"
          companiesgrp.appendChild(Updatebtn_comp)
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
            }).then((response) => {
              if(response.status == 204) flag = true
              else flag = false
            })
          })


          companyDiv1.appendChild(compform)
          compform.style.display = "none"
          //update
          Updatebtn_comp.addEventListener("click", (e) => {
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
            }).then((response) => {
              if(response.status == 201) flag = true
              else flag = false
            })

          })

          companyDiv1.appendChild(Updatebtn_comp)
          companyDiv1.appendChild(Deletebtn_comp)
          companiesgrp.appendChild(companyDiv1)

        })

        //Education
        const educationgrp = document.createElement('article')
        const addeducation = document.createElement('a')
        addeducation.className = "add_link"
          addeducation.style.display = "none"
          if (newUser.education.length < 3) {
            addeducation.textContent = "Add Education"
            addeducation.href = "../html/addeducation.html"
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
          const icon6 = document.createElement('i')
          icon6.className = "fa-solid fa-delete-left"
          Deletebtn_edu.appendChild(icon6)

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
            }).then((response) => {
              if(response.status == 204) flag = true
              else flag = false
            })
          })


          //update  
          const Updatebtn_edu = document.createElement('button')
          Updatebtn_edu.className = "update__btn"
          Updatebtn_edu.textContent = "Update"
          const icon5 = document.createElement('i')
          icon5.className = "fa-solid fa-square-pen"
          Updatebtn_edu.appendChild(icon5)
          // on click - update

          const eduform = document.createElement('form')
          eduform.className = "edu__form"
          const edu_input_name = document.createElement('input')
          edu_input_name.placeholder = "Instuite Name"
          const edu_degree_input = document.createElement('input')
          edu_degree_input.placeholder = "Degree"
          const edu_start_input = document.createElement('input')
          edu_start_input.placeholder = "Start Year"
          const edu_end_input = document.createElement('input')
          edu_end_input.placeholder = "End Year"
          const edu_gpa_input = document.createElement('input')
          edu_gpa_input.placeholder = "GPA"
         
          eduform.appendChild(edu_input_name)
          eduform.appendChild(edu_degree_input)
          eduform.appendChild(edu_gpa_input)
          eduform.appendChild(edu_start_input)
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
            }).then((response) => {
              if(response.status == 201) flag = true
              else flag = false
            })

          })


          educationDiv.appendChild(Updatebtn_edu)
          educationDiv.appendChild(Deletebtn_edu)
          educationgrp.appendChild(educationDiv)

        })


        const hr1 = document.createElement('hr')
        const hr2 = document.createElement('hr')
        const hr3 = document.createElement('hr')
        const hr4 = document.createElement('hr')
        const hr5 = document.createElement('hr')
        const hr6 = document.createElement('hr')
        const hr7 = document.createElement('hr')
        const hr8 = document.createElement('hr')
        const hr9 = document.createElement('hr')
        const hr10 = document.createElement('hr')
        hr1.className = "line"
        hr2.className = "line"
        hr3.className = "line"
        hr4.className = "line"
        hr5.className = "line"
        hr6.className = "line"
        hr7.className = "line"
        hr8.className = "line"
        hr9.className = "line"
        hr10.className = "line"
        div.appendChild(hr10)
        div.appendChild(detail_heading)
        div.appendChild(hr1)
        userElem.appendChild(delDiv)
        div.appendChild(detail)
        div.appendChild(hr2)
        div.appendChild(location_heading)
        div.appendChild(hr3)
        div.appendChild(locationDiv)
        div.appendChild(hr4)
        div.appendChild(skill_heading)
        div.appendChild(hr5)
        div.appendChild(skillGrp)
        div.appendChild(hr6)
        div.appendChild(education_heading)
        div.appendChild(hr7)
        div.appendChild(educationgrp)
        div.appendChild(hr8)
        div.appendChild(company_heading)
        div.appendChild(hr9)
        div.appendChild(companiesgrp)
        parentDiv.appendChild(div)
        userElem.appendChild(parentDiv)

      });
    })
}

window.addEventListener("load", () => {
  showUser(); // already declared somewhere else
  //if(flag == true)location.reload()
});