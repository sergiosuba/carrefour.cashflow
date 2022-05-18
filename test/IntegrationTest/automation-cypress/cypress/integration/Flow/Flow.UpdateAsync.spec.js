describe('API Flow - AddAsync', () => {

    Cypress.config('baseUrl', 'http://localhost:3001/api/')

    let email
    let password

    it('Load data', () => {
        cy.fixture('userLogin').then((user) => {
            email = user.email,
                password = user.password
        })
    })
    var token = ''
    var flowId = ''

    it('POST - Authenticate', () => {
        cy.request('POST', 'user/Authenticate?email=' + email + '&password=' + password)
            .should((response) => {
                expect(response.status).to.eq(200)
                expect(response.body).to.not.be.null
                expect(response.body.value.token).to.not.be.null
                token = response.body.value.token
            })
    })

    it('PUT - UpdateAsync Flow with token null', () => {
        const item = {}
        cy.request({ method: 'PUT', url: 'Flow/UpdateAsync', body: item, failOnStatusCode: false }).its('status').should('eq', 401)
    })

    // add to update test
    //add to delete
    it('POST - AddAsync Flow', () => {
        const item = {
            "flow": "Input"
        }
        const header = { "Authorization": "Bearer " + token }
        cy.request({ method: 'POST', url: 'Flow/AddAsync', body: item, headers: header })
            .should((response) => {
                expect(response.body.value).to.not.be.empty
                expect(response.body.code).to.equal(201)
                expect(response.body.isSuccess).to.equal(true)
                expect(response.body.info).to.equal("Record successfully added")
                flowId = response.body.value.id
            })
    })

    it('PUT - UpdateAsync Flow', () => {
        const item = {
            "id": flowId,
            "flow": "Input test",

        }
        const header = { "Authorization": "Bearer " + token }
        cy.request({ method: 'PUT', url: 'Flow/UpdateAsync', body: item, headers: header })
            .should((response) => {
                expect(response.body.value).to.not.be.empty
                expect(response.body.code).to.equal(200)
                expect(response.body.isSuccess).to.equal(true)
                expect(response.body.info).to.equal("Record successfully updated")
            })
    })
})