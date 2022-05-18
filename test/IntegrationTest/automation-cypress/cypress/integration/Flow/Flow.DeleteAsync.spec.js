describe('API Flow - DeleteAsync', () => {

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

    it('DELETE - DeleteAsync Flow with token null', () => {
        const item = {}
        cy.request({ method: 'DELETE', url: 'Flow/DeleteAsync?id=0AE65F4B-A62E-4929-9371-F1EC6ACC0EF5', body: item, failOnStatusCode: false }).its('status').should('eq', 401)
    })

    //add to delete
    it('POST - AddAsync Flow', () => {
        const item = {
            "flow": "Input test"
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

    it('DELETE - DeleteAsync Flow', () => {
        const item = {

        }
        const header = { "Authorization": "Bearer " + token }
        cy.request({ method: 'DELETE', url: 'Flow/DeleteAsync?id=' + flowId, body: item, headers: header })
            .should((response) => {
                expect(response.body.value).to.be.null
                expect(response.body.code).to.equal(200)
                expect(response.body.isSuccess).to.equal(true)
                expect(response.body.info).to.equal("Record successfully deleted")
            })
    })
})