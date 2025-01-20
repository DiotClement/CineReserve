--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2
-- Dumped by pg_dump version 17.2

-- Started on 2025-01-20 17:07:19

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 217 (class 1259 OID 16393)
-- Name: m_movie; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.m_movie (
    m_title character varying(50) NOT NULL,
    m_description character varying(500),
    m_duration_minutes integer NOT NULL,
    m_star integer,
    m_release_date date,
    m_id integer NOT NULL
);


ALTER TABLE public.m_movie OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 16448)
-- Name: m_movie_m_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.m_movie ALTER COLUMN m_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.m_movie_m_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 218 (class 1259 OID 16408)
-- Name: m_reservation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.m_reservation (
    r_seat_count integer NOT NULL,
    r_fk_showtime_id integer NOT NULL,
    r_id integer NOT NULL
);


ALTER TABLE public.m_reservation OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16430)
-- Name: m_reservation_r_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.m_reservation ALTER COLUMN r_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.m_reservation_r_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 222 (class 1259 OID 16458)
-- Name: m_schedule; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.m_schedule (
    s_id integer NOT NULL,
    s_showtime time without time zone NOT NULL,
    s_fk_movie_id integer NOT NULL
);


ALTER TABLE public.m_schedule OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16457)
-- Name: m_schedule_s_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.m_schedule ALTER COLUMN s_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.m_schedule_s_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 4857 (class 0 OID 16393)
-- Dependencies: 217
-- Data for Name: m_movie; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.m_movie (m_title, m_description, m_duration_minutes, m_star, m_release_date, m_id) FROM stdin;
NOSFERATU	Nosferatu est une fable gothique, l’histoire d’une obsession entre une jeune femme tourmentée et le terrifiant vampire qui s’en est épris, avec toute l’horreur qu’elle va répandre dans son sillage.	133	3	2024-12-25	1
Le Comte de Monte-Cristo	Victime d’un complot, le jeune Edmond Dantès est arrêté le jour de son mariage pour un crime qu’il n’a pas commis. Après quatorze ans de détention au château d’If, il parvient à s’évader. Devenu immensément riche, il revient sous l’identité du comte de Monte-Cristo pour se venger des trois hommes qui l’ont trahi.	178	5	2024-06-28	2
Le Robot Sauvage	Après avoir fait naufrage sur une île déserte, un robot doit apprendre à s adapter à un environnement hostile en nouant petit à petit des relations avec les animaux de l île.	102	4	2024-10-09	3
\.


--
-- TOC entry 4858 (class 0 OID 16408)
-- Dependencies: 218
-- Data for Name: m_reservation; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.m_reservation (r_seat_count, r_fk_showtime_id, r_id) FROM stdin;
2	1	1
3	1	2
\.


--
-- TOC entry 4862 (class 0 OID 16458)
-- Dependencies: 222
-- Data for Name: m_schedule; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.m_schedule (s_id, s_showtime, s_fk_movie_id) FROM stdin;
1	14:00:00	1
2	10:00:00	1
3	18:00:00	1
4	10:00:00	2
5	18:00:00	2
6	22:00:00	2
7	09:00:00	3
8	12:00:00	3
9	14:00:00	3
\.


--
-- TOC entry 4868 (class 0 OID 0)
-- Dependencies: 220
-- Name: m_movie_m_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.m_movie_m_id_seq', 1, false);


--
-- TOC entry 4869 (class 0 OID 0)
-- Dependencies: 219
-- Name: m_reservation_r_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.m_reservation_r_id_seq', 2, true);


--
-- TOC entry 4870 (class 0 OID 0)
-- Dependencies: 221
-- Name: m_schedule_s_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.m_schedule_s_id_seq', 1, false);


--
-- TOC entry 4706 (class 2606 OID 16450)
-- Name: m_movie m_movie_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.m_movie
    ADD CONSTRAINT m_movie_pkey PRIMARY KEY (m_id);


--
-- TOC entry 4708 (class 2606 OID 16432)
-- Name: m_reservation m_reservation_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.m_reservation
    ADD CONSTRAINT m_reservation_pkey PRIMARY KEY (r_id);


--
-- TOC entry 4710 (class 2606 OID 16462)
-- Name: m_schedule m_schedule_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.m_schedule
    ADD CONSTRAINT m_schedule_pkey PRIMARY KEY (s_id);


--
-- TOC entry 4711 (class 2606 OID 16463)
-- Name: m_schedule m_schedule_m_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.m_schedule
    ADD CONSTRAINT m_schedule_m_id_fkey FOREIGN KEY (s_fk_movie_id) REFERENCES public.m_movie(m_id);


-- Completed on 2025-01-20 17:07:19

--
-- PostgreSQL database dump complete
--

