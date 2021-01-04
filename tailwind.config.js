module.exports = {
    purge: [
        './Pages/**/*.cshtml',
    ],
    darkMode: false,
    theme: {
        extend: {},
        screens: {
            sm: '600px',
            md: '900px',
            lg: '1200px',
            xl: '1500px',
            '2xl': '1800px',
        },
        colors: {
            white: '#EEEEEE',
            gray: {
                lighter: '#CFD4E3',
                'post-date': '#A9A9A9',
                light: '#9DA2B2',
                'header-divider': '#454951',
                'sidebar-divider': '#44474E',
                DEFAULT: '#43474F',
                dark: '#36393F',
                darker: '#303339',
                'section-divider': '#2F3237',
            },
            orange: '#E3833D',
        },
        fontFamily: {
            'sans': [
                '"Open Sans"', 'ui-sans-serif', 'system-ui', '-apple-system', 'BlinkMacSystemFont',
                '"Segoe UI"', 'Roboto', '"Helvetica Neue"', 'Arial', '"Noto Sans"', 'sans-serif',
                '"Apple Color Emoji"', '"Segoe UI Emoji"', '"Segoe UI Symbol"', '"Noto Color Emoji"',
            ],
        },
    },
    variants: {
        extend: {
            margin: ['last'],
        },
    },
    plugins: [],
};
