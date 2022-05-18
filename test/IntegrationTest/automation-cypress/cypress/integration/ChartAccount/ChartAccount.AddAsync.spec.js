describe('API ChartAccount - AddAsync', () => {

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

    it('POST - Authenticate', () => {
        cy.request('POST', 'user/Authenticate?email=' + email + '&password=' + password)
            .should((response) => {
                expect(response.status).to.eq(200)
                expect(response.body).to.not.be.null
                expect(response.body.value.token).to.not.be.null
                token = response.body.value.token
            })
    })

    it('POST - AddAsync ChartAccount with token null', () => {
        const item = {}
        cy.request({ method: 'POST', url: 'ChartAccount/AddAsync', body: item, failOnStatusCode: false }).its('status').should('eq', 401)
    })

    it('POST - AddAsync ChartAccount', () => {
        const item = {
            "name": "Vendas",
            "description": "Vendas realizadas"
        }
        const header = { "Authorization": "Bearer " + token }
        cy.request({ method: 'POST', url: 'ChartAccount/AddAsync', body: item, headers: header })
            .should((response) => {
                expect(response.body.value).to.not.be.empty
                expect(response.body.code).to.equal(201)
                expect(response.body.isSuccess).to.equal(true)
                expect(response.body.info).to.equal("Record successfully added")
            })
    })
})